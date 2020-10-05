﻿using System.Collections.Generic;

namespace App.CliSiTef_DLL.ConstantValues
{
    public class RedeAutorizadoraConst
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public string CodigoNome
        {
            get { return (string.IsNullOrWhiteSpace(Codigo) ? "" : (Codigo + "-" + Nome)); }
        }
    }

    public class RedeAutorizadora
    {
        public static List<RedeAutorizadoraConst> RetornarLista()
        {
            return new List<RedeAutorizadoraConst>()
            {
                new RedeAutorizadoraConst() { Codigo = "00000", Nome = "OUTRA, NÃO DEFINIDA" },
                new RedeAutorizadoraConst() { Codigo = "00001", Nome = "TECBAN" },
                new RedeAutorizadoraConst() { Codigo = "00002", Nome = "ITAÚ" },
                new RedeAutorizadoraConst() { Codigo = "00003", Nome = "BRADESCO" },
                new RedeAutorizadoraConst() { Codigo = "00004", Nome = "VISANET - ESPECIFICAÇÃO 200001" },
                new RedeAutorizadoraConst() { Codigo = "00005", Nome = "REDECARD" },
                new RedeAutorizadoraConst() { Codigo = "00006", Nome = "AMEX" },
                new RedeAutorizadoraConst() { Codigo = "00007", Nome = "SOLLO" },
                new RedeAutorizadoraConst() { Codigo = "00008", Nome = "E CAPTURE" },
                new RedeAutorizadoraConst() { Codigo = "00009", Nome = "SERASA" },
                new RedeAutorizadoraConst() { Codigo = "00010", Nome = "SPC BRASIL" },
                new RedeAutorizadoraConst() { Codigo = "00011", Nome = "SERASA DETALHADO" },
                new RedeAutorizadoraConst() { Codigo = "00012", Nome = "TELEDATA" },
                new RedeAutorizadoraConst() { Codigo = "00013", Nome = "ACSP" },
                new RedeAutorizadoraConst() { Codigo = "00014", Nome = "ACSP DETALHADO" },
                new RedeAutorizadoraConst() { Codigo = "00015", Nome = "TECBIZ" },
                new RedeAutorizadoraConst() { Codigo = "00016", Nome = "CDL DF" },
                new RedeAutorizadoraConst() { Codigo = "00017", Nome = "REPOM" },
                new RedeAutorizadoraConst() { Codigo = "00018", Nome = "STANDBY" },
                new RedeAutorizadoraConst() { Codigo = "00019", Nome = "EDMCARD" },
                new RedeAutorizadoraConst() { Codigo = "00020", Nome = "CREDICESTA" },
                new RedeAutorizadoraConst() { Codigo = "00021", Nome = "BANRISUL" },
                new RedeAutorizadoraConst() { Codigo = "00022", Nome = "ACC CARD" },
                new RedeAutorizadoraConst() { Codigo = "00023", Nome = "CLUBCARD" },
                new RedeAutorizadoraConst() { Codigo = "00024", Nome = "ACPR" },
                new RedeAutorizadoraConst() { Codigo = "00025", Nome = "VIDALINK" },
                new RedeAutorizadoraConst() { Codigo = "00026", Nome = "CCC_WEB" },
                new RedeAutorizadoraConst() { Codigo = "00027", Nome = "EDIGUAY" },
                new RedeAutorizadoraConst() { Codigo = "00028", Nome = "CARREFOUR" },
                new RedeAutorizadoraConst() { Codigo = "00029", Nome = "SOFTWAY" },
                new RedeAutorizadoraConst() { Codigo = "00030", Nome = "MULTICHEQUE" },
                new RedeAutorizadoraConst() { Codigo = "00031", Nome = "TICKET COMBUSTÍVEL" },
                new RedeAutorizadoraConst() { Codigo = "00032", Nome = "YAMADA" },
                new RedeAutorizadoraConst() { Codigo = "00033", Nome = "CITIBANK" },
                new RedeAutorizadoraConst() { Codigo = "00034", Nome = "INFOCARD" },
                new RedeAutorizadoraConst() { Codigo = "00035", Nome = "BESC" },
                new RedeAutorizadoraConst() { Codigo = "00036", Nome = "EMS" },
                new RedeAutorizadoraConst() { Codigo = "00037", Nome = "CHEQUE CASH" },
                new RedeAutorizadoraConst() { Codigo = "00038", Nome = "CENTRAL CARD" },
                new RedeAutorizadoraConst() { Codigo = "00039", Nome = "DROGARAIA" },
                new RedeAutorizadoraConst() { Codigo = "00040", Nome = "OUTRO SERVIÇO" },
                new RedeAutorizadoraConst() { Codigo = "00041", Nome = "EDENRED" },
                new RedeAutorizadoraConst() { Codigo = "00042", Nome = "EPAY GIFT" },
                new RedeAutorizadoraConst() { Codigo = "00043", Nome = "PARATI" },
                new RedeAutorizadoraConst() { Codigo = "00044", Nome = "TOKORO" },
                new RedeAutorizadoraConst() { Codigo = "00045", Nome = "COOPERCRED" },
                new RedeAutorizadoraConst() { Codigo = "00046", Nome = "SERVCEL" },
                new RedeAutorizadoraConst() { Codigo = "00047", Nome = "SOROCRED" },
                new RedeAutorizadoraConst() { Codigo = "00048", Nome = "VITAL" },
                new RedeAutorizadoraConst() { Codigo = "00049", Nome = "SAX FINANCEIRA" },
                new RedeAutorizadoraConst() { Codigo = "00050", Nome = "FORMOSA" },
                new RedeAutorizadoraConst() { Codigo = "00051", Nome = "HIPERCARD" },
                new RedeAutorizadoraConst() { Codigo = "00052", Nome = "TRICARD" },
                new RedeAutorizadoraConst() { Codigo = "00053", Nome = "CHECK OK" },
                new RedeAutorizadoraConst() { Codigo = "00054", Nome = "POLICARD" },
                new RedeAutorizadoraConst() { Codigo = "00055", Nome = "CETELEM CARREFOUR" },
                new RedeAutorizadoraConst() { Codigo = "00056", Nome = "LEADER" },
                new RedeAutorizadoraConst() { Codigo = "00057", Nome = "CONSÓRCIO CREDICARD VENEZUELA" },
                new RedeAutorizadoraConst() { Codigo = "00058", Nome = "GAZINCRED" },
                new RedeAutorizadoraConst() { Codigo = "00059", Nome = "TELENET" },
                new RedeAutorizadoraConst() { Codigo = "00060", Nome = "CHEQUE PRÉ" },
                new RedeAutorizadoraConst() { Codigo = "00061", Nome = "BRASIL CARD" },
                new RedeAutorizadoraConst() { Codigo = "00062", Nome = "EPHARMA" },
                new RedeAutorizadoraConst() { Codigo = "00063", Nome = "TOTAL" },
                new RedeAutorizadoraConst() { Codigo = "00064", Nome = "CONSÓRCIO AMEX VENEZUELA" },
                new RedeAutorizadoraConst() { Codigo = "00065", Nome = "GAX" },
                new RedeAutorizadoraConst() { Codigo = "00066", Nome = "PERALTA" },
                new RedeAutorizadoraConst() { Codigo = "00067", Nome = "SERVIDOR PAGAMENTO" },
                new RedeAutorizadoraConst() { Codigo = "00068", Nome = "BANESE" },
                new RedeAutorizadoraConst() { Codigo = "00069", Nome = "RESOMAQ" },
                new RedeAutorizadoraConst() { Codigo = "00070", Nome = "SYSDATA" },
                new RedeAutorizadoraConst() { Codigo = "00071", Nome = "CDL POA" },
                new RedeAutorizadoraConst() { Codigo = "00072", Nome = "BIGCARD" },
                new RedeAutorizadoraConst() { Codigo = "00073", Nome = "DTRANSFER" },
                new RedeAutorizadoraConst() { Codigo = "00074", Nome = "VIAVAREJO" },
                new RedeAutorizadoraConst() { Codigo = "00075", Nome = "CHECK EXPRESS" },
                new RedeAutorizadoraConst() { Codigo = "00076", Nome = "GIVEX" },
                new RedeAutorizadoraConst() { Codigo = "00077", Nome = "VALECARD" },
                new RedeAutorizadoraConst() { Codigo = "00078", Nome = "PORTAL CARD" },
                new RedeAutorizadoraConst() { Codigo = "00079", Nome = "BANPARA" },
                new RedeAutorizadoraConst() { Codigo = "00080", Nome = "SOFTNEX" },
                new RedeAutorizadoraConst() { Codigo = "00081", Nome = "SUPERCARD" },
                new RedeAutorizadoraConst() { Codigo = "00082", Nome = "GETNET" },
                new RedeAutorizadoraConst() { Codigo = "00083", Nome = "PREVSAUDE" },
                new RedeAutorizadoraConst() { Codigo = "00084", Nome = "BANCO POTTENCIAL" },
                new RedeAutorizadoraConst() { Codigo = "00085", Nome = "SOPHUS" },
                new RedeAutorizadoraConst() { Codigo = "00086", Nome = "MARISA 2" },
                new RedeAutorizadoraConst() { Codigo = "00087", Nome = "MAXICRED" },
                new RedeAutorizadoraConst() { Codigo = "00088", Nome = "BLACKHAWK" },
                new RedeAutorizadoraConst() { Codigo = "00089", Nome = "EXPANSIVA" },
                new RedeAutorizadoraConst() { Codigo = "00090", Nome = "SAS NT" },
                new RedeAutorizadoraConst() { Codigo = "00091", Nome = "LEADER 2" },
                new RedeAutorizadoraConst() { Codigo = "00092", Nome = "SOMAR" },
                new RedeAutorizadoraConst() { Codigo = "00093", Nome = "CETELEM AURA" },
                new RedeAutorizadoraConst() { Codigo = "00094", Nome = "CABAL" },
                new RedeAutorizadoraConst() { Codigo = "00095", Nome = "CREDSYSTEM" },
                new RedeAutorizadoraConst() { Codigo = "00096", Nome = "BANCO PROVINCIAL" },
                new RedeAutorizadoraConst() { Codigo = "00097", Nome = "CARTESYS" },
                new RedeAutorizadoraConst() { Codigo = "00098", Nome = "CISA" },
                new RedeAutorizadoraConst() { Codigo = "00099", Nome = "TRNCENTRE" },
                new RedeAutorizadoraConst() { Codigo = "00100", Nome = "ACPR D" },
                new RedeAutorizadoraConst() { Codigo = "00101", Nome = "CARDCO" },
                new RedeAutorizadoraConst() { Codigo = "00102", Nome = "CHECK CHECK" },
                new RedeAutorizadoraConst() { Codigo = "00103", Nome = "CADASA" },
                new RedeAutorizadoraConst() { Codigo = "00104", Nome = "PRIVATE BRADESCO" },
                new RedeAutorizadoraConst() { Codigo = "00105", Nome = "CREDMAIS" },
                new RedeAutorizadoraConst() { Codigo = "00106", Nome = "GWCEL" },
                new RedeAutorizadoraConst() { Codigo = "00107", Nome = "CHECK EXPRESS 2" },
                new RedeAutorizadoraConst() { Codigo = "00108", Nome = "GETNET PBM" },
                new RedeAutorizadoraConst() { Codigo = "00109", Nome = "USECRED" },
                new RedeAutorizadoraConst() { Codigo = "00110", Nome = "SERV VOUCHER" },
                new RedeAutorizadoraConst() { Codigo = "00111", Nome = "TREDENEXX" },
                new RedeAutorizadoraConst() { Codigo = "00112", Nome = "BONUS PRESENTE CARREFOUR" },
                new RedeAutorizadoraConst() { Codigo = "00113", Nome = "CREDISHOP" },
                new RedeAutorizadoraConst() { Codigo = "00114", Nome = "ESTAPAR" },
                new RedeAutorizadoraConst() { Codigo = "00115", Nome = "BANCO IBI" },
                new RedeAutorizadoraConst() { Codigo = "00116", Nome = "WORKERCARD" },
                new RedeAutorizadoraConst() { Codigo = "00117", Nome = "TELECHEQUE" },
                new RedeAutorizadoraConst() { Codigo = "00118", Nome = "OBOE" },
                new RedeAutorizadoraConst() { Codigo = "00119", Nome = "PROTEGE" },
                new RedeAutorizadoraConst() { Codigo = "00120", Nome = "SERASA CARDS" },
                new RedeAutorizadoraConst() { Codigo = "00121", Nome = "HOTCARD" },
                new RedeAutorizadoraConst() { Codigo = "00122", Nome = "BANCO PANAMERICANO" },
                new RedeAutorizadoraConst() { Codigo = "00123", Nome = "BANCO MERCANTIL" },
                new RedeAutorizadoraConst() { Codigo = "00124", Nome = "SIGACRED" },
                new RedeAutorizadoraConst() { Codigo = "00125", Nome = "VISANET – ESPECIFICAÇÃO 4.1" },
                new RedeAutorizadoraConst() { Codigo = "00126", Nome = "SPTRANS" },
                new RedeAutorizadoraConst() { Codigo = "00127", Nome = "PRESENTE MARISA" },
                new RedeAutorizadoraConst() { Codigo = "00128", Nome = "COOPLIFE" },
                new RedeAutorizadoraConst() { Codigo = "00129", Nome = "BOD" },
                new RedeAutorizadoraConst() { Codigo = "00130", Nome = "G CARD" },
                new RedeAutorizadoraConst() { Codigo = "00131", Nome = "TCREDIT" },
                new RedeAutorizadoraConst() { Codigo = "00132", Nome = "SISCRED" },
                new RedeAutorizadoraConst() { Codigo = "00133", Nome = "FOXWINCARDS" },
                new RedeAutorizadoraConst() { Codigo = "00134", Nome = "CONVCARD" },
                new RedeAutorizadoraConst() { Codigo = "00135", Nome = "VOUCHER" },
                new RedeAutorizadoraConst() { Codigo = "00136", Nome = "EXPAND CARDS" },
                new RedeAutorizadoraConst() { Codigo = "00137", Nome = "ULTRAGAZ" },
                new RedeAutorizadoraConst() { Codigo = "00138", Nome = "QUALICARD" },
                new RedeAutorizadoraConst() { Codigo = "00139", Nome = "HSBC UK" },
                new RedeAutorizadoraConst() { Codigo = "00140", Nome = "WAPPA" },
                new RedeAutorizadoraConst() { Codigo = "00141", Nome = "SQCF" },
                new RedeAutorizadoraConst() { Codigo = "00142", Nome = "INTELLISYS" },
                new RedeAutorizadoraConst() { Codigo = "00143", Nome = "BOD DÉBITO" },
                new RedeAutorizadoraConst() { Codigo = "00144", Nome = "ACCREDITO" },
                new RedeAutorizadoraConst() { Codigo = "00145", Nome = "COMPROCARD" },
                new RedeAutorizadoraConst() { Codigo = "00146", Nome = "ORGCARD" },
                new RedeAutorizadoraConst() { Codigo = "00147", Nome = "MINASCRED" },
                new RedeAutorizadoraConst() { Codigo = "00148", Nome = "FARMÁCIA POPULAR" },
                new RedeAutorizadoraConst() { Codigo = "00149", Nome = "FIDELIDADE MAIS" },
                new RedeAutorizadoraConst() { Codigo = "00150", Nome = "ITAÚ SHOPLINE" },
                new RedeAutorizadoraConst() { Codigo = "00151", Nome = "CDL RIO" },
                new RedeAutorizadoraConst() { Codigo = "00152", Nome = "FORTCARD" },
                new RedeAutorizadoraConst() { Codigo = "00153", Nome = "PAGGO" },
                new RedeAutorizadoraConst() { Codigo = "00154", Nome = "SMARTNET" },
                new RedeAutorizadoraConst() { Codigo = "00155", Nome = "INTERFARMACIA" },
                new RedeAutorizadoraConst() { Codigo = "00156", Nome = "VALECON" },
                new RedeAutorizadoraConst() { Codigo = "00157", Nome = "CARTÃO EVANGÉLICO" },
                new RedeAutorizadoraConst() { Codigo = "00158", Nome = "VEGASCARD" },
                new RedeAutorizadoraConst() { Codigo = "00159", Nome = "SCCARD" },
                new RedeAutorizadoraConst() { Codigo = "00160", Nome = "ORBITALL" },
                new RedeAutorizadoraConst() { Codigo = "00161", Nome = "ICARDS" },
                new RedeAutorizadoraConst() { Codigo = "00162", Nome = "FACILCARD" },
                new RedeAutorizadoraConst() { Codigo = "00163", Nome = "FIDELIZE" },
                new RedeAutorizadoraConst() { Codigo = "00164", Nome = "FINAMAX" },
                new RedeAutorizadoraConst() { Codigo = "00165", Nome = "BANCO GE" },
                new RedeAutorizadoraConst() { Codigo = "00166", Nome = "UNIK" },
                new RedeAutorizadoraConst() { Codigo = "00167", Nome = "TIVIT" },
                new RedeAutorizadoraConst() { Codigo = "00168", Nome = "VALIDATA" },
                new RedeAutorizadoraConst() { Codigo = "00169", Nome = "BANESCARD" },
                new RedeAutorizadoraConst() { Codigo = "00170", Nome = "CSU CARREFOUR" },
                new RedeAutorizadoraConst() { Codigo = "00171", Nome = "VALESHOP" },
                new RedeAutorizadoraConst() { Codigo = "00172", Nome = "SOMAR CARD" },
                new RedeAutorizadoraConst() { Codigo = "00173", Nome = "OMNION" },
                new RedeAutorizadoraConst() { Codigo = "00174", Nome = "CONDOR" },
                new RedeAutorizadoraConst() { Codigo = "00175", Nome = "STANDBYDUP" },
                new RedeAutorizadoraConst() { Codigo = "00176", Nome = "BPAG BOLDCRON" },
                new RedeAutorizadoraConst() { Codigo = "00177", Nome = "MARISA SAX SYSIN" },
                new RedeAutorizadoraConst() { Codigo = "00178", Nome = "STARFICHE" },
                new RedeAutorizadoraConst() { Codigo = "00179", Nome = "ACE SEGUROS" },
                new RedeAutorizadoraConst() { Codigo = "00180", Nome = "TOP CARD" },
                new RedeAutorizadoraConst() { Codigo = "00181", Nome = "GETNET LAC" },
                new RedeAutorizadoraConst() { Codigo = "00182", Nome = "UP SIGHT" },
                new RedeAutorizadoraConst() { Codigo = "00183", Nome = "MAR" },
                new RedeAutorizadoraConst() { Codigo = "00184", Nome = "FUNCIONAL CARD" },
                new RedeAutorizadoraConst() { Codigo = "00185", Nome = "PHARMA SYSTEM" },
                new RedeAutorizadoraConst() { Codigo = "00186", Nome = "MARKET PAY" },
                new RedeAutorizadoraConst() { Codigo = "00187", Nome = "SICREDI" },
                new RedeAutorizadoraConst() { Codigo = "00188", Nome = "ESCALENA" },
                new RedeAutorizadoraConst() { Codigo = "00189", Nome = "N SERVIÇOS" },
                new RedeAutorizadoraConst() { Codigo = "00190", Nome = "CSF CARREFOUR" },
                new RedeAutorizadoraConst() { Codigo = "00191", Nome = "ATP" },
                new RedeAutorizadoraConst() { Codigo = "00192", Nome = "AVST" },
                new RedeAutorizadoraConst() { Codigo = "00193", Nome = "ALGORIX" },
                new RedeAutorizadoraConst() { Codigo = "00194", Nome = "AMEX EMV" },
                new RedeAutorizadoraConst() { Codigo = "00195", Nome = "COMPREMAX" },
                new RedeAutorizadoraConst() { Codigo = "00196", Nome = "LIBERCARD" },
                new RedeAutorizadoraConst() { Codigo = "00197", Nome = "SEICON" },
                new RedeAutorizadoraConst() { Codigo = "00198", Nome = "SERASA AUTORIZ CRÉDITO" },
                new RedeAutorizadoraConst() { Codigo = "00199", Nome = "SMARTN" },
                new RedeAutorizadoraConst() { Codigo = "00200", Nome = "PLATCO" },
                new RedeAutorizadoraConst() { Codigo = "00201", Nome = "SMARTNET EMV" },
                new RedeAutorizadoraConst() { Codigo = "00202", Nome = "PROSA MÉXICO" },
                new RedeAutorizadoraConst() { Codigo = "00203", Nome = "PEELA" },
                new RedeAutorizadoraConst() { Codigo = "00204", Nome = "NUTRIK" },
                new RedeAutorizadoraConst() { Codigo = "00205", Nome = "GOLDENFARMA PBM" },
                new RedeAutorizadoraConst() { Codigo = "00206", Nome = "GLOBAL PAYMENTS" },
                new RedeAutorizadoraConst() { Codigo = "00207", Nome = "ELAVON" },
                new RedeAutorizadoraConst() { Codigo = "00208", Nome = "CTF" },
                new RedeAutorizadoraConst() { Codigo = "00209", Nome = "BANESTIK" },
                new RedeAutorizadoraConst() { Codigo = "00210", Nome = "VISA ARG" },
                new RedeAutorizadoraConst() { Codigo = "00211", Nome = "AMEX ARG" },
                new RedeAutorizadoraConst() { Codigo = "00212", Nome = "POSNET ARG" },
                new RedeAutorizadoraConst() { Codigo = "00213", Nome = "AMEX MÉXICO" },
                new RedeAutorizadoraConst() { Codigo = "00214", Nome = "ELETROZEMA" },
                new RedeAutorizadoraConst() { Codigo = "00215", Nome = "BARIGUI" },
                new RedeAutorizadoraConst() { Codigo = "00216", Nome = "SIMEC" },
                new RedeAutorizadoraConst() { Codigo = "00217", Nome = "SGF" },
                new RedeAutorizadoraConst() { Codigo = "00218", Nome = "HUG" },
                new RedeAutorizadoraConst() { Codigo = "00219", Nome = "CARTÃO CONSIGNUM CARTÃO METTACARD" },
                new RedeAutorizadoraConst() { Codigo = "00220", Nome = "DDTOTAL" },
                new RedeAutorizadoraConst() { Codigo = "00221", Nome = "CARTÃO QUALIDADE" },
                new RedeAutorizadoraConst() { Codigo = "00222", Nome = "REDECONV" },
                new RedeAutorizadoraConst() { Codigo = "00223", Nome = "NUTRICARD" },
                new RedeAutorizadoraConst() { Codigo = "00224", Nome = "DOTZ" },
                new RedeAutorizadoraConst() { Codigo = "00225", Nome = "PREMIAÇÕES RAIZEN" },
                new RedeAutorizadoraConst() { Codigo = "00226", Nome = "TROCO SOLIDÁRIO" },
                new RedeAutorizadoraConst() { Codigo = "00227", Nome = "AMBEV SÓCIO TORCEDOR" },
                new RedeAutorizadoraConst() { Codigo = "00228", Nome = "SEMPRE" },
                new RedeAutorizadoraConst() { Codigo = "00229", Nome = "BIN" },
                new RedeAutorizadoraConst() { Codigo = "00230", Nome = "COCIPA" },
                new RedeAutorizadoraConst() { Codigo = "00231", Nome = "IBI MÉXICO" },
                new RedeAutorizadoraConst() { Codigo = "00232", Nome = "SIANET" },
                new RedeAutorizadoraConst() { Codigo = "00233", Nome = "SGCARDS" },
                new RedeAutorizadoraConst() { Codigo = "00234", Nome = "CIAGROUP" },
                new RedeAutorizadoraConst() { Codigo = "00235", Nome = "FILLIP" },
                new RedeAutorizadoraConst() { Codigo = "00236", Nome = "CONDUCTOR" },
                new RedeAutorizadoraConst() { Codigo = "00237", Nome = "LTM RAIZEN" },
                new RedeAutorizadoraConst() { Codigo = "00238", Nome = "INCOMM" },
                new RedeAutorizadoraConst() { Codigo = "00239", Nome = "VISA PASS FIRST" },
                new RedeAutorizadoraConst() { Codigo = "00240", Nome = "CENCOSUD" },
                new RedeAutorizadoraConst() { Codigo = "00241", Nome = "HIPERLIFE" },
                new RedeAutorizadoraConst() { Codigo = "00242", Nome = "SITPOS" },
                new RedeAutorizadoraConst() { Codigo = "00243", Nome = "AGT" },
                new RedeAutorizadoraConst() { Codigo = "00244", Nome = "MIRA" },
                new RedeAutorizadoraConst() { Codigo = "00245", Nome = "AMBEV 2 SÓCIO TORCEDOR" },
                new RedeAutorizadoraConst() { Codigo = "00246", Nome = "JGV" },
                new RedeAutorizadoraConst() { Codigo = "00247", Nome = "CREDSAT" },
                new RedeAutorizadoraConst() { Codigo = "00248", Nome = "BRAZILIAN CARD" },
                new RedeAutorizadoraConst() { Codigo = "00249", Nome = "RIACHUELO" },
                new RedeAutorizadoraConst() { Codigo = "00250", Nome = "ITS RAIZEN" },
                new RedeAutorizadoraConst() { Codigo = "00251", Nome = "SIMCRED" },
                new RedeAutorizadoraConst() { Codigo = "00252", Nome = "BANCRED CARD" },
                new RedeAutorizadoraConst() { Codigo = "00253", Nome = "CONEKTA" },
                new RedeAutorizadoraConst() { Codigo = "00254", Nome = "SOFTCARD" },
                new RedeAutorizadoraConst() { Codigo = "00255", Nome = "ECOPAG" },
                new RedeAutorizadoraConst() { Codigo = "00256", Nome = "C&A AUTOMAÇÃO IBI" },
                new RedeAutorizadoraConst() { Codigo = "00257", Nome = "C&A PARCERIAS BRADESCARD" },
                new RedeAutorizadoraConst() { Codigo = "00258", Nome = "OGLOBA" },
                new RedeAutorizadoraConst() { Codigo = "00259", Nome = "BANESE VOUCHER" },
                new RedeAutorizadoraConst() { Codigo = "00260", Nome = "RAPP" },
                new RedeAutorizadoraConst() { Codigo = "00261", Nome = "MONITORA POS" },
                new RedeAutorizadoraConst() { Codigo = "00262", Nome = "SOLLUS" },
                new RedeAutorizadoraConst() { Codigo = "00263", Nome = "FITCARD" },
                new RedeAutorizadoraConst() { Codigo = "00264", Nome = "ADIANTI" },
                new RedeAutorizadoraConst() { Codigo = "00265", Nome = "STONE" },
                new RedeAutorizadoraConst() { Codigo = "00266", Nome = "DMCARD" },
                new RedeAutorizadoraConst() { Codigo = "00267", Nome = "ICATU 2" },
                new RedeAutorizadoraConst() { Codigo = "00268", Nome = "FARMASEG" },
                new RedeAutorizadoraConst() { Codigo = "00269", Nome = "BIZ" },
                new RedeAutorizadoraConst() { Codigo = "00270", Nome = "SEMPARAR RAIZEN" },
                new RedeAutorizadoraConst() { Codigo = "00272", Nome = "PBM GLOBAL" },
                new RedeAutorizadoraConst() { Codigo = "00271", Nome = "CARDSE" },
                new RedeAutorizadoraConst() { Codigo = "00273", Nome = "PAYSMART" },
                new RedeAutorizadoraConst() { Codigo = "00275", Nome = "ONEBOX" },
                new RedeAutorizadoraConst() { Codigo = "00276", Nome = "CARTO" },
                new RedeAutorizadoraConst() { Codigo = "00277", Nome = "WAYUP" },
                new RedeAutorizadoraConst() { Codigo = "00296", Nome = "SAFRA" },
                new RedeAutorizadoraConst() { Codigo = "00301", Nome = "CTF FROTA" },
                new RedeAutorizadoraConst() { Codigo = "00303", Nome = "SIPAG" }
            };
        }
        public static RedeAutorizadoraConst RetornarAutorizadora(string _codigo)
        {
            return RetornarLista().Find(p => p.Codigo == _codigo);
        }
    }
}
