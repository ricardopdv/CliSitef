﻿using App.CliSiTef_DLL.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Vip.Printer;

namespace App.CliSiTef_DLL
{
    public partial class FrmTelaTesteVenda : Form
    {
        int mStatusTefInicio { get; set; }
        decimal gValorTotalDaTransacao { get; set; }
        decimal gValorDasTransacoesEfetuadas { get; set; }

        TefSoftwareExpress mTefSoftwareExpress = new TefSoftwareExpress();
        
        TefConfig mTefConfig { get; set; }
        Cupom mCupomVenda { get; set; }

        void CarregarConfiguracao()
        {
            mTefConfig = new TefConfig
            {
                Tef_PathArquivos = Application.StartupPath,
                Tef_Ip = ConfigurationManager.AppSettings["Tef_Ip"],
                Tef_Empresa = ConfigurationManager.AppSettings["Tef_Empresa"],
                Tef_EmpresaCnpj = ConfigurationManager.AppSettings["Tef_EmpresaCnpj"],
                Tef_Terminal = ConfigurationManager.AppSettings["Tef_Terminal"],
                Tef_SoftwareHouseCnpj = ConfigurationManager.AppSettings["Tef_SoftwareHouseCnpj"],
                Tef_PinPadPorta = ConfigurationManager.AppSettings["Tef_PinPadPorta"],
                Tef_PinPadMensagem = ConfigurationManager.AppSettings["Tef_PinPadMensagem"],
                Tef_PinPadVerificar = ConfigurationManager.AppSettings["Tef_PinPadVerificar"] == "1"
            };

            string path = Application.StartupPath + "\\CliSiTef.ini";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("[Redes]");
                    sw.WriteLine("HabilitaRedeTelecheque=1");
                    sw.WriteLine("HabilitaRedeSigaCred=1");
                    sw.WriteLine("HabilitaRedeSoftWay=1");
                    sw.WriteLine("");
                    sw.WriteLine("[PinPad]");
                    sw.WriteLine("Tipo=Compartilhado");
                    sw.WriteLine("");
                    sw.WriteLine("[PinPadCompartilhado]");
                    sw.WriteLine("Porta=" + mTefConfig.Tef_PinPadPorta);
                    sw.WriteLine("");
                    sw.WriteLine("[CliSiTef]");
                    sw.WriteLine("HabilitaTrace=1");
                    sw.WriteLine("");
                    sw.WriteLine("[CliSiTefI]");
                    sw.WriteLine("HabilitaTrace=1");
                    sw.WriteLine("");
                    sw.WriteLine("[SiTef]");
                    sw.WriteLine("MantemConexaoAtiva=1");
                    sw.WriteLine("TempoEsperaConexao=10");
                    sw.WriteLine("");
                    sw.WriteLine("[Geral]");
                    sw.WriteLine("TransacoesAdicionaisHabilitadas=7;8;16;20;26;27;29;30;40;42;43;3014;3985");
                    sw.WriteLine("");
                    sw.WriteLine("[SrvCliSiTef]");
                    sw.WriteLine("IpSiTef=" + mTefConfig.Tef_Ip);
                    sw.WriteLine("");
                    sw.WriteLine("[RecargaCelular]");
                    sw.WriteLine(";0-nao solicita/1-Pinpad/2-PDV");
                    sw.WriteLine("TipoConfirmacaoNumeroCelular=2");
                    sw.WriteLine("HabilitaRecargaMultiConcessionaria=1");
                    sw.Flush();
                }
            }
        }
        void CarregarImpresorasInstaladas()
        {
            cmbImpressoraNome.Items.Add("");
            foreach (string impressora in PrinterSettings.InstalledPrinters)
            {
                cmbImpressoraNome.Items.Add(impressora);
            }

            cmbImpressoraNome.SelectedIndex = 0;
        }
        void Comprovante(string _documentoVinculado, List<TefRetorno> _lstComprovante, Printer _printer)
        {
            if (_lstComprovante != null && _lstComprovante.Count > 0)
            {
                _printer.AlignCenter();
                _printer.BoldMode(Vip.Printer.Enums.PrinterModeState.On);
                _printer.WriteLine("Nome Fantasia");
                _printer.WriteLine("Razao Social da Empresa");
                _printer.WriteLine("Rua Endereco da empresa, numero");
                _printer.WriteLine("Cep - Cidade/Uf");
                _printer.WriteLine("C.N.P.J  -  Inscricao Estadual");
                _printer.WriteLine("----------------------------------------------");
                _printer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "      Cupom: " + _documentoVinculado);
                _printer.WriteLine("----------------------------------------------");
                _printer.BoldMode(Vip.Printer.Enums.PrinterModeState.Off);
                _printer.AlignLeft();

                foreach (TefRetorno item in _lstComprovante)
                {
                    if (item != null)
                    {
                        string linha = item.Valor?.Replace("\"", "");
                        if (!string.IsNullOrWhiteSpace(linha))
                            _printer.WriteLine(linha);
                    }
                }
                _printer.BoldMode(Vip.Printer.Enums.PrinterModeState.On);
                _printer.WriteLine("----------------------------------------------");
                _printer.WriteLine("Caixa: " + mTefConfig.Tef_Terminal);
                _printer.WriteLine("----------------------------------------------");
                _printer.BoldMode(Vip.Printer.Enums.PrinterModeState.Off);
                _printer.NewLines(4);
                _printer.PartialPaperCut();
                _printer.PrintDocument();
                _printer.Clear();
            }
        }
        void ImprimirComprovantes(string _documentoVinculado)
        {
            if (cmbImpressoraTipo.SelectedIndex <= 0)
                return;
            if (cmbImpressoraNome.SelectedIndex <= 0)
                return;

            if (mTefSoftwareExpress.gCupomVenda != null)
            {
                if (mTefSoftwareExpress.gCupomVenda.Transacoes.Count > 0)
                {
                    foreach (TefTransacao itemTransacaoItem in mTefSoftwareExpress.gCupomVenda.Transacoes)
                    {
                        List<TefRetorno> lstComprovanteCliente = itemTransacaoItem.Retornos.Where(p => p.Codigo == 713).OrderBy(p => p.Indice).ToList();
                        List<TefRetorno> lstComprovanteEstab = itemTransacaoItem.Retornos.Where(p => p.Codigo == 715).OrderBy(p => p.Indice).ToList();

                        Vip.Printer.Enums.PrinterType printerType = Vip.Printer.Enums.PrinterType.Epson;
                        if (cmbImpressoraTipo.SelectedIndex == 2)
                            printerType = Vip.Printer.Enums.PrinterType.Bematech;
                        else if (cmbImpressoraTipo.SelectedIndex == 3)
                            printerType = Vip.Printer.Enums.PrinterType.Daruma;

                        Printer printer = new Printer(cmbImpressoraNome.Text, printerType);
                        Comprovante(_documentoVinculado, lstComprovanteCliente, printer);
                        Comprovante(_documentoVinculado, lstComprovanteEstab, printer);
                    }
                }
            }
        }
        void ExibirMensagem(string _msg, int _tempoMilisegundos = 2000)
        {
            lblMensagem.Invoke((MethodInvoker)delegate
            {
                lblMensagem.Text = _msg;
                lblMensagem.Refresh();
                Thread.Sleep(_tempoMilisegundos);
                if (_tempoMilisegundos > 0)
                {
                    lblMensagem.Text = "";
                    lblMensagem.Refresh();
                }
            });
        }
        void LimparRetornoTef()
        {
            if (mTefSoftwareExpress.gCupomVenda != null)
            {
                mTefSoftwareExpress.gCupomVenda.Transacoes.Clear();
                mTefSoftwareExpress.gCupomVenda = null;
            }
            if (mCupomVenda != null)
                mCupomVenda = null;
        }

        public FrmTelaTesteVenda()
        {
            InitializeComponent();
            pnlBody.Enabled = false;
            mTefSoftwareExpress.OnMessageClient += new TefSoftwareExpress.OnMessageClientHandle(MTefSoftwareExpress_OnMessageClient);
            mTefSoftwareExpress.OnCallForm += new TefSoftwareExpress.OnCallFormtHandle(MTefSoftwareExpress_OnCallForm);
        }

        private void MTefSoftwareExpress_OnMessageClient(string _mensagem, int _tempoMiliSegundos)
        {
            lblMensagem.Invoke((MethodInvoker)delegate
            {
                lblMensagem.Text = _mensagem;
                lblMensagem.Refresh();
                Thread.Sleep(_tempoMiliSegundos);
            });
        }
        private void MTefSoftwareExpress_OnCallForm(TefFuncaoInterativa _tefFuncaoInterativa)
        {
            if (_tefFuncaoInterativa != null)
            {
                if (_tefFuncaoInterativa.DataType == DataTypeEnum.Await)
                {
                    using (FrmTefAguarde frm = new FrmTefAguarde())
                    {
                        frm.gMensagem = _tefFuncaoInterativa.Mensagem;
                        frm.ShowDialog();
                    }
                }
                else if(_tefFuncaoInterativa.DataType == DataTypeEnum.Confirmation)
                {
                    if (MessageBox.Show(_tefFuncaoInterativa.Mensagem, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        _tefFuncaoInterativa.RespostaSitef = "0";
                    if (_tefFuncaoInterativa.TipoCampo == 5013 && _tefFuncaoInterativa.RespostaSitef == "1")
                        _tefFuncaoInterativa.Interromper = false;
                }
                else if (_tefFuncaoInterativa.DataType == DataTypeEnum.Menu)
                {
                    using (FrmTefMenu frm = new FrmTefMenu())
                    {
                        frm.gTitulo = _tefFuncaoInterativa.Titulo;
                        frm.gItens = _tefFuncaoInterativa.ItensMenu;
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                            _tefFuncaoInterativa.RespostaSitef = (frm.gSelecionado + 1).ToString();
                        else
                            _tefFuncaoInterativa.Interromper = true;
                    }
                }
                else if (_tefFuncaoInterativa.DataType == DataTypeEnum.Numeric)
                {
                    if (_tefFuncaoInterativa.TipoCampo != 500)
                    {
                        using (FrmTefColetaDados frm = new FrmTefColetaDados())
                        {
                            frm.gTitulo = _tefFuncaoInterativa.Titulo;
                            frm.gTamanhoMinimo = _tefFuncaoInterativa.TamanhoMinimo;
                            frm.gTamanhoMaximo = _tefFuncaoInterativa.TamanhoMaximo;
                            frm.gTipoDeDados = DataTypeEnum.Numeric;
                            frm.ShowDialog();
                            if (frm.DialogResult == DialogResult.OK)
                                _tefFuncaoInterativa.RespostaSitef = frm.txtDados.Text;
                            else
                                _tefFuncaoInterativa.Interromper = true;
                        }
                    }
                }
                else if (_tefFuncaoInterativa.DataType == DataTypeEnum.Currency)
                {
                    if (_tefFuncaoInterativa.TipoCampo == 130 || _tefFuncaoInterativa.TipoCampo == 146 || _tefFuncaoInterativa.TipoCampo == 504)
                    {
                        using (FrmTefColetaDados frm = new FrmTefColetaDados())
                        {
                            frm.gTitulo = _tefFuncaoInterativa.Titulo;
                            frm.gTamanhoMinimo = _tefFuncaoInterativa.TamanhoMinimo;
                            frm.gTamanhoMaximo = _tefFuncaoInterativa.TamanhoMaximo;
                            frm.gTipoDeDados = DataTypeEnum.Currency;
                            frm.ShowDialog();
                            if (frm.DialogResult == DialogResult.OK)
                            {
                                string valorReposta = "";
                                if (!string.IsNullOrWhiteSpace(frm.txtDados.Text) && Convert.ToDecimal(frm.txtDados.Text) > 0)
                                    valorReposta = Convert.ToDecimal(frm.txtDados.Text).ToString("N2");
                                _tefFuncaoInterativa.RespostaSitef = valorReposta;
                            }
                            else
                                _tefFuncaoInterativa.Interromper = true;
                        }
                    }
                }
                else if (_tefFuncaoInterativa.DataType == DataTypeEnum.QrCode)
                {
                    if (_tefFuncaoInterativa.TipoCampo == 584)
                    {
                        if (!string.IsNullOrWhiteSpace(_tefFuncaoInterativa.Mensagem))
                        {
                            using (FrmTefQrCode frm = new FrmTefQrCode())
                            {
                                frm.gTitulo = _tefFuncaoInterativa.Titulo;
                                frm.gStrQrCode = _tefFuncaoInterativa.Mensagem;
                                frm.ShowDialog();
                                if (frm.DialogResult == DialogResult.OK)
                                    _tefFuncaoInterativa.RespostaSitef = frm.lblQrCode.Text;
                                else
                                    _tefFuncaoInterativa.Interromper = true;
                            }
                        }
                    }
                }
            }
        }

        private void FrmTelaTesteVenda_Load(object sender, EventArgs e)
        {
            CarregarConfiguracao();
            cmbImpressoraTipo.SelectedIndex = 0;
            CarregarImpresorasInstaladas();
        }
        private void FrmTelaTesteVenda_Shown(object sender, EventArgs e)
        {
            ExibirMensagem("Aguarde inicializando TEF-SiTef", 0);
            bkgInicioTef.RunWorkerAsync();
        }

        private void txtDocumentoVinculado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
                e.Handled = true;
        }

        private void btnDocumentoVinculadoGerar_Click(object sender, EventArgs e)
        {
            txtDocumentoVinculado.Text = new Random().Next(999999).ToString("000000");
        }
        private void btnAtv_Click(object sender, EventArgs e)
        {
            ExibirMensagem(mTefSoftwareExpress.MensagemTef(mTefSoftwareExpress.Atv()));
        }
        private void btnAdm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumentoVinculado.Text) || Convert.ToInt32(txtDocumentoVinculado.Text) <= 0)
            {
                MessageBox.Show("Digite o número do documento vinculado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDocumentoVinculado.Focus();
                return;
            }

            if (mCupomVenda == null)
            {
                mCupomVenda = new Cupom
                {
                    TipoOperacao = "Adm",
                    DocumentoVinculado = txtDocumentoVinculado.Text,
                    ValorTotal = 0
                };
            }
            Guid identificadorTransacao = Guid.NewGuid();
            mTefSoftwareExpress.gCupomVenda = mCupomVenda;

            int sts = mTefSoftwareExpress.Adm(identificadorTransacao, txtDocumentoVinculado.Text);
            if (sts == 0)
            {
                ImprimirComprovantes(txtDocumentoVinculado.Text);
                LimparRetornoTef();
                txtDocumentoVinculado.Text = "";
            }
            else
            {
                mCupomVenda = null;
                ExibirMensagem(mTefSoftwareExpress.MensagemTef(sts));
            }
        }
        private void btnRecarga_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumentoVinculado.Text) || Convert.ToInt32(txtDocumentoVinculado.Text) <= 0)
            {
                MessageBox.Show("Digite o número do documento vinculado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDocumentoVinculado.Focus();
                return;
            }

            if (mCupomVenda == null)
            {
                mCupomVenda = new Cupom
                {
                    TipoOperacao = "Cel",
                    DocumentoVinculado = txtDocumentoVinculado.Text,
                    ValorTotal = 0
                };
            }
            Guid identificadorTransacao = Guid.NewGuid();
            mTefSoftwareExpress.gCupomVenda = mCupomVenda;

            int sts = mTefSoftwareExpress.RecargaCelular(identificadorTransacao, txtDocumentoVinculado.Text);
            if (sts == 0)
            {
                ImprimirComprovantes(txtDocumentoVinculado.Text);
                LimparRetornoTef();
                lblMensagem.Text = "";
                lblMensagem.Refresh();
                txtValorVenda.Text = "0,00";
                txtDocumentoVinculado.Text = "";
            }
            else
            {
                mCupomVenda = null;
                ExibirMensagem(mTefSoftwareExpress.MensagemTef(sts));
            }
            txtDocumentoVinculado.Focus();
        }
        private void btnCrt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumentoVinculado.Text) || Convert.ToInt32(txtDocumentoVinculado.Text) <= 0)
            {
                MessageBox.Show("Digite o número do documento vinculado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDocumentoVinculado.Focus();
                return;
            }
            if (Convert.ToDecimal(txtValorVenda.Text) <= 0m)
            {
                MessageBox.Show("Digite o valor da operação", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValorVenda.Focus();
                return;
            }

            gValorTotalDaTransacao = Convert.ToDecimal(txtValorVenda.Text);

            decimal valorParaEstaTransacao = (gValorTotalDaTransacao - gValorDasTransacoesEfetuadas);
            using (FrmConfirmarValor frm = new FrmConfirmarValor(valorParaEstaTransacao))
            {
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.Cancel)
                    return;

                valorParaEstaTransacao = frm.gValorParaEstaTransacao;
                if (gValorTotalDaTransacao < (gValorDasTransacoesEfetuadas + valorParaEstaTransacao))
                {
                    MessageBox.Show("Valor para finalizar as transações é maior que o valor total da transação", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                gValorDasTransacoesEfetuadas += valorParaEstaTransacao;
            }

            if (mCupomVenda == null)
            {
                mCupomVenda = new Cupom
                {
                    TipoOperacao = "Crt",
                    DocumentoVinculado = txtDocumentoVinculado.Text,
                    ValorTotal = gValorTotalDaTransacao
                };
            }
            Guid identificadorTransacao = Guid.NewGuid();
            mTefSoftwareExpress.gCupomVenda = mCupomVenda;

            bool confirmarCnf = gValorTotalDaTransacao == gValorDasTransacoesEfetuadas;
            int sts = mTefSoftwareExpress.Crt(identificadorTransacao, valorParaEstaTransacao, txtDocumentoVinculado.Text, "Adriano", _confirmarCnf: confirmarCnf);
            if (sts == 0)
            {
                if (confirmarCnf)
                {
                    ImprimirComprovantes(txtDocumentoVinculado.Text);
                    LimparRetornoTef();
                    lblMensagem.Text = "";
                    lblMensagem.Refresh();
                    btnDocumentoVinculadoGerar.Enabled = true;
                    txtDocumentoVinculado.ReadOnly = false;
                    txtValorVenda.ReadOnly = false;
                    txtValorVenda.Text = "0,00";
                    txtDocumentoVinculado.Text = "";
                    gValorTotalDaTransacao = 0M;
                    gValorDasTransacoesEfetuadas = 0M;
                }
                else
                {
                    lblMensagem.Text = "Falta o pagamento restante de: " + (gValorTotalDaTransacao - gValorDasTransacoesEfetuadas).ToString("C2");
                    lblMensagem.Refresh();
                    btnDocumentoVinculadoGerar.Enabled = false;
                    txtDocumentoVinculado.ReadOnly = true;
                    txtValorVenda.ReadOnly = true;
                }
            }
            else
            {
                if (gValorTotalDaTransacao == gValorDasTransacoesEfetuadas)
                {
                    gValorDasTransacoesEfetuadas = 0M;
                    LimparRetornoTef();
                }
                else
                    gValorDasTransacoesEfetuadas -= valorParaEstaTransacao;
                ExibirMensagem(mTefSoftwareExpress.MensagemTef(sts));
            }
            txtDocumentoVinculado.Focus();
        }
        private void btnCrtDebito_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumentoVinculado.Text) || Convert.ToInt32(txtDocumentoVinculado.Text) <= 0)
            {
                MessageBox.Show("Digite o número do documento vinculado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDocumentoVinculado.Focus();
                return;
            }
            if (Convert.ToDecimal(txtValorVenda.Text) <= 0m)
            {
                MessageBox.Show("Digite o valor da operação", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValorVenda.Focus();
                return;
            }

            gValorTotalDaTransacao = Convert.ToDecimal(txtValorVenda.Text);

            decimal valorParaEstaTransacao = (gValorTotalDaTransacao - gValorDasTransacoesEfetuadas);
            using (FrmConfirmarValor frm = new FrmConfirmarValor(valorParaEstaTransacao))
            {
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.Cancel)
                    return;

                valorParaEstaTransacao = frm.gValorParaEstaTransacao;
                if (gValorTotalDaTransacao < (gValorDasTransacoesEfetuadas + valorParaEstaTransacao))
                {
                    MessageBox.Show("Valor para finalizar as transações é maior que o valor total da transação", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                gValorDasTransacoesEfetuadas += valorParaEstaTransacao;
            }

            if (mCupomVenda == null)
            {
                mCupomVenda = new Cupom
                {
                    TipoOperacao = "Crt",
                    DocumentoVinculado = txtDocumentoVinculado.Text,
                    ValorTotal = gValorTotalDaTransacao
                };
            }
            Guid identificadorTransacao = Guid.NewGuid();
            mTefSoftwareExpress.gCupomVenda = mCupomVenda;

            bool confirmarCnf = gValorTotalDaTransacao == gValorDasTransacoesEfetuadas;
            int sts = mTefSoftwareExpress.Crt(identificadorTransacao, valorParaEstaTransacao, txtDocumentoVinculado.Text, "Adriano", 2, confirmarCnf);
            if (sts == 0)
            {
                if (confirmarCnf)
                {
                    ImprimirComprovantes(txtDocumentoVinculado.Text);
                    LimparRetornoTef();
                    lblMensagem.Text = "";
                    lblMensagem.Refresh();
                    btnDocumentoVinculadoGerar.Enabled = true;
                    txtDocumentoVinculado.ReadOnly = false;
                    txtValorVenda.ReadOnly = false;
                    txtValorVenda.Text = "0,00";
                    txtDocumentoVinculado.Text = "";
                    gValorTotalDaTransacao = 0M;
                    gValorDasTransacoesEfetuadas = 0M;
                }
                else
                {
                    lblMensagem.Text = "Falta o pagamento restante de: " + (gValorTotalDaTransacao - gValorDasTransacoesEfetuadas).ToString("C2");
                    lblMensagem.Refresh();
                    btnDocumentoVinculadoGerar.Enabled = false;
                    txtDocumentoVinculado.ReadOnly = true;
                    txtValorVenda.ReadOnly = true;
                }
            }
            else
            {
                if (gValorTotalDaTransacao == gValorDasTransacoesEfetuadas)
                {
                    gValorDasTransacoesEfetuadas = 0M;
                    LimparRetornoTef();
                }
                else
                    gValorDasTransacoesEfetuadas -= valorParaEstaTransacao;
                ExibirMensagem(mTefSoftwareExpress.MensagemTef(sts));
            }
            txtDocumentoVinculado.Focus();
        }
        private void btnCrtCredito_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumentoVinculado.Text) || Convert.ToInt32(txtDocumentoVinculado.Text) <= 0)
            {
                MessageBox.Show("Digite o número do documento vinculado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDocumentoVinculado.Focus();
                return;
            }
            if (Convert.ToDecimal(txtValorVenda.Text) <= 0m)
            {
                MessageBox.Show("Digite o valor da operação", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValorVenda.Focus();
                return;
            }

            gValorTotalDaTransacao = Convert.ToDecimal(txtValorVenda.Text);

            decimal valorParaEstaTransacao = (gValorTotalDaTransacao - gValorDasTransacoesEfetuadas);
            using (FrmConfirmarValor frm = new FrmConfirmarValor(valorParaEstaTransacao))
            {
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.Cancel)
                    return;

                valorParaEstaTransacao = frm.gValorParaEstaTransacao;
                if (gValorTotalDaTransacao < (gValorDasTransacoesEfetuadas + valorParaEstaTransacao))
                {
                    MessageBox.Show("Valor para finalizar as transações é maior que o valor total da transação", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                gValorDasTransacoesEfetuadas += valorParaEstaTransacao;
            }

            if (mCupomVenda == null)
            {
                mCupomVenda = new Cupom
                {
                    TipoOperacao = "Crt",
                    DocumentoVinculado = txtDocumentoVinculado.Text,
                    ValorTotal = gValorTotalDaTransacao
                };
            }
            Guid identificadorTransacao = Guid.NewGuid();
            mTefSoftwareExpress.gCupomVenda = mCupomVenda;

            bool confirmarCnf = gValorTotalDaTransacao == gValorDasTransacoesEfetuadas;
            int sts = mTefSoftwareExpress.Crt(identificadorTransacao, valorParaEstaTransacao, txtDocumentoVinculado.Text, "Adriano", 3, confirmarCnf);
            if (sts == 0)
            {
                if (confirmarCnf)
                {
                    ImprimirComprovantes(txtDocumentoVinculado.Text);
                    LimparRetornoTef();
                    lblMensagem.Text = "";
                    lblMensagem.Refresh();
                    btnDocumentoVinculadoGerar.Enabled = true;
                    txtDocumentoVinculado.ReadOnly = false;
                    txtValorVenda.ReadOnly = false;
                    txtValorVenda.Text = "0,00";
                    txtDocumentoVinculado.Text = "";
                    gValorTotalDaTransacao = 0M;
                    gValorDasTransacoesEfetuadas = 0M;
                }
                else
                {
                    lblMensagem.Text = "Falta o pagamento restante de: " + (gValorTotalDaTransacao - gValorDasTransacoesEfetuadas).ToString("C2");
                    lblMensagem.Refresh();
                    btnDocumentoVinculadoGerar.Enabled = false;
                    txtDocumentoVinculado.ReadOnly = true;
                    txtValorVenda.ReadOnly = true;
                }
            }
            else
            {
                if (gValorTotalDaTransacao == gValorDasTransacoesEfetuadas)
                {
                    gValorDasTransacoesEfetuadas = 0M;
                    LimparRetornoTef();
                }
                else
                    gValorDasTransacoesEfetuadas -= valorParaEstaTransacao;
                ExibirMensagem(mTefSoftwareExpress.MensagemTef(sts));
            }
            txtDocumentoVinculado.Focus();
        }
        private void btnCrtCd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumentoVinculado.Text) || Convert.ToInt32(txtDocumentoVinculado.Text) <= 0)
            {
                MessageBox.Show("Digite o número do documento vinculado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDocumentoVinculado.Focus();
                return;
            }
            if (Convert.ToDecimal(txtValorVenda.Text) <= 0m)
            {
                MessageBox.Show("Digite o valor da operação", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValorVenda.Focus();
                return;
            }

            gValorTotalDaTransacao = Convert.ToDecimal(txtValorVenda.Text);

            decimal valorParaEstaTransacao = (gValorTotalDaTransacao - gValorDasTransacoesEfetuadas);
            using (FrmConfirmarValor frm = new FrmConfirmarValor(valorParaEstaTransacao))
            {
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.Cancel)
                    return;

                valorParaEstaTransacao = frm.gValorParaEstaTransacao;
                if (gValorTotalDaTransacao < (gValorDasTransacoesEfetuadas + valorParaEstaTransacao))
                {
                    MessageBox.Show("Valor para finalizar as transações é maior que o valor total da transação", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                gValorDasTransacoesEfetuadas += valorParaEstaTransacao;
            }

            if (mCupomVenda == null)
            {
                mCupomVenda = new Cupom
                {
                    TipoOperacao = "Crt",
                    DocumentoVinculado = txtDocumentoVinculado.Text,
                    ValorTotal = gValorTotalDaTransacao
                };
            }
            Guid identificadorTransacao = Guid.NewGuid();
            mTefSoftwareExpress.gCupomVenda = mCupomVenda;

            bool confirmarCnf = gValorTotalDaTransacao == gValorDasTransacoesEfetuadas;
            int sts = mTefSoftwareExpress.Crt(identificadorTransacao, valorParaEstaTransacao, txtDocumentoVinculado.Text, "Adriano", 122, confirmarCnf);
            if (sts == 0)
            {
                if (confirmarCnf)
                {
                    ImprimirComprovantes(txtDocumentoVinculado.Text);
                    LimparRetornoTef();
                    lblMensagem.Text = "";
                    lblMensagem.Refresh();
                    btnDocumentoVinculadoGerar.Enabled = true;
                    txtDocumentoVinculado.ReadOnly = false;
                    txtValorVenda.ReadOnly = false;
                    txtValorVenda.Text = "0,00";
                    txtDocumentoVinculado.Text = "";
                    gValorTotalDaTransacao = 0M;
                    gValorDasTransacoesEfetuadas = 0M;
                }
                else
                {
                    lblMensagem.Text = "Falta o pagamento restante de: " + (gValorTotalDaTransacao - gValorDasTransacoesEfetuadas).ToString("C2");
                    lblMensagem.Refresh();
                    btnDocumentoVinculadoGerar.Enabled = false;
                    txtDocumentoVinculado.ReadOnly = true;
                    txtValorVenda.ReadOnly = true;
                }
            }
            else
            {
                if (gValorTotalDaTransacao == gValorDasTransacoesEfetuadas)
                {
                    gValorDasTransacoesEfetuadas = 0M;
                    LimparRetornoTef();
                }
                else
                    gValorDasTransacoesEfetuadas -= valorParaEstaTransacao;
                ExibirMensagem(mTefSoftwareExpress.MensagemTef(sts));
            }
            txtDocumentoVinculado.Focus();
        }
        private void btnCnc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumentoVinculado.Text) || Convert.ToInt32(txtDocumentoVinculado.Text) <= 0)
            {
                MessageBox.Show("Digite o número do documento vinculado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDocumentoVinculado.Focus();
                return;
            }

            if (mCupomVenda == null)
            {
                mCupomVenda = new Cupom
                {
                    TipoOperacao = "Cnc",
                    DocumentoVinculado = txtDocumentoVinculado.Text,
                    ValorTotal = 0
                };
            }
            Guid identificadorTransacao = Guid.NewGuid();
            mTefSoftwareExpress.gCupomVenda = mCupomVenda;

            int sts = mTefSoftwareExpress.Cnc(identificadorTransacao, txtDocumentoVinculado.Text, "Adriano");
            if (sts == 0)
            {
                ImprimirComprovantes(txtDocumentoVinculado.Text);
                LimparRetornoTef();
                lblMensagem.Text = "";
                lblMensagem.Refresh();
                txtValorVenda.Text = "0,00";
                txtDocumentoVinculado.Text = "";
            }
            else
            {
                mCupomVenda = null;
                ExibirMensagem(mTefSoftwareExpress.MensagemTef(sts));
            }
            txtDocumentoVinculado.Focus();
        }
        private void btnCncDebito_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumentoVinculado.Text) || Convert.ToInt32(txtDocumentoVinculado.Text) <= 0)
            {
                MessageBox.Show("Digite o número do documento vinculado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDocumentoVinculado.Focus();
                return;
            }

            if (mCupomVenda == null)
            {
                mCupomVenda = new Cupom
                {
                    TipoOperacao = "Cnc",
                    DocumentoVinculado = txtDocumentoVinculado.Text,
                    ValorTotal = 0
                };
            }
            Guid identificadorTransacao = Guid.NewGuid();
            mTefSoftwareExpress.gCupomVenda = mCupomVenda;

            int sts = mTefSoftwareExpress.Cnc(identificadorTransacao, txtDocumentoVinculado.Text, "Adriano", 211);
            if (sts == 0)
            {
                ImprimirComprovantes(txtDocumentoVinculado.Text);
                LimparRetornoTef();
                lblMensagem.Text = "";
                lblMensagem.Refresh();
                txtValorVenda.Text = "0,00";
                txtDocumentoVinculado.Text = "";
            }
            else
            {
                mCupomVenda = null;
                ExibirMensagem(mTefSoftwareExpress.MensagemTef(sts));
            }
            txtDocumentoVinculado.Focus();
        }
        private void btnCncCredito_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumentoVinculado.Text) || Convert.ToInt32(txtDocumentoVinculado.Text) <= 0)
            {
                MessageBox.Show("Digite o número do documento vinculado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDocumentoVinculado.Focus();
                return;
            }

            if (mCupomVenda == null)
            {
                mCupomVenda = new Cupom
                {
                    TipoOperacao = "Cnc",
                    DocumentoVinculado = txtDocumentoVinculado.Text,
                    ValorTotal = 0
                };
            }
            Guid identificadorTransacao = Guid.NewGuid();
            mTefSoftwareExpress.gCupomVenda = mCupomVenda;

            int sts = mTefSoftwareExpress.Cnc(identificadorTransacao, txtDocumentoVinculado.Text, "Adriano", 210);
            if (sts == 0)
            {
                ImprimirComprovantes(txtDocumentoVinculado.Text);
                LimparRetornoTef();
                lblMensagem.Text = "";
                lblMensagem.Refresh();
                txtValorVenda.Text = "0,00";
                txtDocumentoVinculado.Text = "";
            }
            else
            {
                mCupomVenda = null;
                ExibirMensagem(mTefSoftwareExpress.MensagemTef(sts));
            }
            txtDocumentoVinculado.Focus();
        }
        private void btnCncCd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumentoVinculado.Text) || Convert.ToInt32(txtDocumentoVinculado.Text) <= 0)
            {
                MessageBox.Show("Digite o número do documento vinculado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDocumentoVinculado.Focus();
                return;
            }

            if (mCupomVenda == null)
            {
                mCupomVenda = new Cupom
                {
                    TipoOperacao = "Cnc",
                    DocumentoVinculado = txtDocumentoVinculado.Text,
                    ValorTotal = 0
                };
            }
            Guid identificadorTransacao = Guid.NewGuid();
            mTefSoftwareExpress.gCupomVenda = mCupomVenda;

            int sts = mTefSoftwareExpress.Cnc(identificadorTransacao, txtDocumentoVinculado.Text, "Adriano", 123);
            if (sts == 0)
            {
                ImprimirComprovantes(txtDocumentoVinculado.Text);
                LimparRetornoTef();
                lblMensagem.Text = "";
                lblMensagem.Refresh();
                txtValorVenda.Text = "0,00";
                txtDocumentoVinculado.Text = "";
            }
            else
            {
                mCupomVenda = null;
                ExibirMensagem(mTefSoftwareExpress.MensagemTef(sts));
            }
            txtDocumentoVinculado.Focus();
        }

        private void bkgInicioTef_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            mStatusTefInicio = mTefSoftwareExpress.InicializarTef(mTefConfig);
        }
        private void bkgInicioTef_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (mStatusTefInicio > 0)
                ExibirMensagem(mTefSoftwareExpress.MensagemTef(mStatusTefInicio), 3000);
            else
                ExibirMensagem("TEF-SiTef inicializado com sucesso", 1000);
            pnlBody.Enabled = mStatusTefInicio == 0;
            mStatusTefInicio = 0;
        }
    }
}