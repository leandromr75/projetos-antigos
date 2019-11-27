using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RDI.Lince;
using RDI.NFe2.Business;
using RDI.NFe2.ORMAP;
using RDI.NFe2.SchemaXML;

namespace RDI.NFe.Visual
{
    public partial class FrmEditNota : Form
    {
        FrmInfNRec oFrm;

        public NotaFiscal oNFe;
        public FrmEditNota()
        {
            InitializeComponent();
        }

        private void FrmEditNota_Load(object sender, EventArgs e)
        {
            DoRefresh();
        }

        private void btCancela_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btImprime_Click(object sender, EventArgs e)
        {
            ClientEnvironment manager = null;
            Parametro oParam = null;
            try
            {
                manager = Conexao.CreateManager(Program.ConAux);
                oParam = Program.GetParametro(Program.empresaSelecionada, manager);

                if (oNFe.codigoSituacao == TipoSituacaoNota.Aprovada || oNFe.codigoSituacao == TipoSituacaoNota.Impressa)//aprovada ou impressa
                {
                    NFeUtils.ImprimeDANFe(oNFe, oParam, manager);
                    DoRefresh();
                    MessageBox.Show("Arquivo enviado para servidor de impress�o.");
                }
                else
                {
                    MessageBox.Show("Nota n�o esta aprovada pela SEFAZ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                oParam = null;
                Conexao.DisposeManager(manager);
            }
        }

        private void DoRefresh()
        {
            ClientEnvironment manager = null;

            try
            {
                manager = Conexao.CreateManager(Program.ConAux);

                oNFe = (NotaFiscal)NotaFiscalDAL.Instance.Find(oNFe.GetKeyString(), manager);


                txChaveNota.Text = oNFe.chaveNota;
                txLote.Text = oNFe.numeroLote.ToString();
                txCodSit.Text = oNFe.codigoSituacao.ToString();
                txDatSit.Text = oNFe.dataSituacao.ToString();
                txDesSit.Text = oNFe.descricaoSituacao;

                if (!String.IsNullOrEmpty(oNFe.cStat))
                    txcStat.Text = oNFe.cStat;
                if (!String.IsNullOrEmpty(oNFe.xMotivo))
                    txxMotivo.Text = oNFe.xMotivo;
                if (!String.IsNullOrEmpty(oNFe.nProt))
                    txnProt.Text = oNFe.nProt;
                if (!String.IsNullOrEmpty(oNFe.nProtCancelamento))
                    txnProtCanc.Text = oNFe.nProtCancelamento;



                System.Xml.XmlDocument xmlNota = new System.Xml.XmlDocument();
                xmlNota.LoadXml(oNFe.xmlNota);
                NFeUtils.PopulaTreeView(xmlNota, tvXmlNota);
                if (oNFe.codigoSituacao == TipoSituacaoNota.XMLInvalido) //xml invalido
                {
                    tvProcFinal.Visible = false;
                    tbProcFinal.Visible = true;
                    tbProcFinal.Text = oNFe.xmlProcesso;
                }
                else if (!String.IsNullOrEmpty(oNFe.xmlProcesso))
                {
                    xmlNota.LoadXml(oNFe.xmlProcesso);
                    NFeUtils.PopulaTreeView(xmlNota, tvProcFinal);
                }


                //carregar eventos
                dgvEventos.AutoGenerateColumns = false;
                dgvEventos.DataSource = oNFe.CarregarEventos(manager);


                System.Xml.XmlDocument xmlCancelamento = new System.Xml.XmlDocument();
                if (!String.IsNullOrEmpty(oNFe.xmlPedidoCancelamento))
                {
                    xmlCancelamento.LoadXml(oNFe.xmlPedidoCancelamento);
                    NFeUtils.PopulaTreeView(xmlCancelamento, tvXmlCancelamento);
                }
                if (!String.IsNullOrEmpty(oNFe.xmlProcessoCancelamento))
                {
                    xmlCancelamento.LoadXml(oNFe.xmlProcessoCancelamento);
                    NFeUtils.PopulaTreeView(xmlCancelamento, tvProcCancelamento);
                }
                xmlCancelamento = null;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.DisposeManager(manager);
            }
        }









        private void btRefreshId_Click(object sender, EventArgs e)
        {
            //mensagem de confirma��o
            if (MessageBox.Show("Deseja realmente atualizar esse registro pelo ID ?",
                "Atualizar pelo ID", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string erro = String.Empty;

                ClientEnvironment manager = Conexao.CreateManager(Program.ConAux);
                FuncaoAutomacao oFuncao = new FuncaoAutomacao(Program.empresaSelecionada, manager, Program.enviarInformacoesSobreErros);

                if (oFuncao.AtualizarNFePeloID(oNFe, out erro))
                {
                    DoRefresh();
                }
                else
                {
                    MessageBox.Show(erro);
                }

                oFuncao = null;
                Conexao.DisposeManager(manager);
            }
        }






        private void dgvEventos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(2))
            {
                try
                {
                    FrmVisualizaXML oFrmXML = new FrmVisualizaXML(
                        ((Evento)dgvEventos.Rows[e.RowIndex].DataBoundItem).XMLPedido);
                    oFrmXML.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (e.ColumnIndex.Equals(3))
            {
                try
                {
                    FrmVisualizaXML oFrmXML = new FrmVisualizaXML(
                        ((Evento)dgvEventos.Rows[e.RowIndex].DataBoundItem).XMLResposta);
                    oFrmXML.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (e.ColumnIndex.Equals(4))
            {
                try
                {
                    oEvento = (Evento)dgvEventos.Rows[e.RowIndex].DataBoundItem;

                    if (oEvento.codigoSituacao != TipoSituacaoEvento.FinalizadoAprovado135 &&
                        oEvento.codigoSituacao != TipoSituacaoEvento.FinalizadoAprovado136 &&
                        oEvento.codigoSituacao != TipoSituacaoEvento.FinalizadoAprovado155)
                    {
                        throw new Exception("Evento n�o aprovado");
                    }


                    //solicitar usuario local para save
                    sfdProcNFeCCe.Filter = "Arquivo XML|*.xml";
                    sfdProcNFeCCe.Title = "Salvar arquivo";

                    string sufixo = "";
                    if (oEvento.tpEvento == TEventoInfEventoTpEvento.CartaCorrecao)
                        sufixo = "_v1.00-procCCe.xml";
                    else if (oEvento.tpEvento == TEventoInfEventoTpEvento.Cancelamento)
                        sufixo = "_v1.00-procEventoCancNFe.xml";
                    else
                        sufixo = ".xml";

                    sfdProcNFeCCe.FileName = ((ITEvento)Servicos.CarregaXML_STR(oEvento.XMLPedido,
                        oNFe.versao,
                    "TEvento")).infEvento.Id + sufixo;

                    sfdProcNFeCCe.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    oEvento = null;
                }
            }
            else if (e.ColumnIndex.Equals(5))
            {
                //gerar arquivo para danfe.exe
                #region imprimir evento

                ClientEnvironment manager = null;
                Parametro oParam = null;

                try
                {
                    manager = Conexao.CreateManager(Program.ConAux);
                    oParam = Program.GetParametro(Program.empresaSelecionada, manager);
                    oEvento = (Evento)dgvEventos.Rows[e.RowIndex].DataBoundItem;

                    if (oEvento.codigoSituacao != TipoSituacaoEvento.FinalizadoAprovado135 &&
                        oEvento.codigoSituacao != TipoSituacaoEvento.FinalizadoAprovado136 &&
                        oEvento.codigoSituacao != TipoSituacaoEvento.FinalizadoAprovado155)
                    {
                        throw new Exception("Evento n�o aprovado");
                    }

                    //tratar envio de xml para destinat�rio.
                    string sufixo = "";
                    if (oEvento.tpEvento == TEventoInfEventoTpEvento.CartaCorrecao)
                        sufixo = "_v1.00-procCCe.xml";
                    else if (oEvento.tpEvento == TEventoInfEventoTpEvento.Cancelamento)
                    {
                        sufixo = "_v1.00-procEventoCancNFe.xml";
                    }
                    else
                        sufixo = ".xml";

                    String nomeArquivo = ((ITEvento)Servicos.CarregaXML_STR(oEvento.XMLPedido,
                        oNFe.versao,
                    "TEvento")).infEvento.Id + sufixo;

                    ITNFe oNFeXML = (ITNFe)
                        Servicos.CarregaXML_STR(oNFe.xmlNota,
                        oNFe.versao,
                        "TNFe");

                    //salvar TXT com dados complementares
                    if (File.Exists(oParam.pastaImpressao + nomeArquivo.Replace(".xml", ".txt")))
                        File.Delete(oParam.pastaImpressao + nomeArquivo.Replace(".xml", ".txt"));

                    //gerar arquivo TXT com o email do destinat�rio
                    using (StreamWriter oSW = File.CreateText(oParam.pastaImpressao + nomeArquivo.Replace(".xml", ".txt")))
                    {
                        //dados destinatarios
                        oSW.WriteLine(oNFeXML.infNFe.dest.xNome);
                        oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.xLgr + ", " + oNFeXML.infNFe.dest.enderDest.nro);
                        oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.xBairro);
                        oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.CEP);
                        oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.xMun);
                        oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.fone);
                        oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.UF);
                        oSW.WriteLine(oNFeXML.infNFe.dest.IE);

                        //dados emitente
                        oSW.WriteLine(oNFeXML.infNFe.emit.xNome);
                        oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.xLgr + ", " + oNFeXML.infNFe.emit.enderEmit.nro);
                        oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.xBairro);
                        oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.CEP);
                        oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.xMun);
                        oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.fone);
                        oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.UF);
                        oSW.WriteLine(oNFeXML.infNFe.emit.IE);

                        oSW.WriteLine(oNFeXML.infNFe.ide.nNF);
                        oSW.WriteLine(oNFeXML.infNFe.ide.serie);
                        oSW.WriteLine(oNFeXML.infNFe.ide.dEmi);

                        oSW.Close();
                    }
                    GC.Collect();

                    NFeUtils.GeraArquivoProcEventoNFe(oEvento, oParam.pastaImpressao + nomeArquivo, oNFe.versao);

                    MessageBox.Show("Arquivo enviado para servidor de impress�o.");

                    oNFeXML = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    oEvento = null;
                    Conexao.DisposeManager(manager);
                    oParam = null;
                }
                #endregion
            }
        }

        Evento oEvento;

        void sfdProcNFe_FileOkCCe(object sender, CancelEventArgs e)
        {
            try
            {


                NFeUtils.GeraArquivoProcEventoNFe(oEvento, sfdProcNFeCCe.FileName, oNFe.versao);

                MessageBox.Show("Arquivo gerado com sucesso em : " + sfdProcNFeCCe.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void button2_Click(object sender, EventArgs e)
        {
            //cancelamento
            try
            {
                if (oNFe.codigoSituacao != TipoSituacaoNota.Aprovada && oNFe.codigoSituacao != TipoSituacaoNota.Impressa) //aprovada ou impressa
                {
                    if (oNFe.codigoSituacao == TipoSituacaoNota.Cancelada)
                    {
                        throw new Exception("Nota j� cancelada.");
                    }
                    else
                    {
                        throw new Exception("Nota n�o foi aprovada pela SEFAZ.");
                    }
                }

                oFrm = new FrmInfNRec();
                oFrm.Text = "Cancelamento por evento";
                oFrm.LabelPergunta.Text = "Informe o motivo do cancelamento";

                oFrm.DoOnOkClick += new EventHandler(oFrm_DoOnOkEvtCanc_Click);
                oFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        void oFrm_DoOnOkEvtCanc_Click(object sender, EventArgs e)
        {
            ClientEnvironment manager = null;
            Parametro oParam = null;

            try
            {
                if (String.IsNullOrEmpty(oFrm.TextResposta.Text))
                    throw new Exception("Motivo n�o foi informado.");

                manager = Conexao.CreateManager(Program.ConAux);
                oParam = Program.GetParametro(Program.empresaSelecionada, manager);


                //verificar se j� existe algum evento desse tipo registrado para a NFe
                //verificar nSeqEvento
                int nSeqEvento = oNFe.CarregarEventos(manager)
                    .Count(ev => ev.tpEvento == TEventoInfEventoTpEvento.Cancelamento &&
                        (ev.codigoSituacao == TipoSituacaoEvento.FinalizadoAprovado135 ||
                         ev.codigoSituacao == TipoSituacaoEvento.FinalizadoAprovado136 ||
                         ev.codigoSituacao == TipoSituacaoEvento.FinalizadoAprovado155))
                        + 1;

                var oEvento = (ITEvento)Servicos.XMLFactory(oParam.versao, "TEvento");
                var oProtNFe = (ITProtNFe)Servicos.CarregaXML_STR(oNFe.xmlProcesso, oNFe.versao, "TProtNFe");

                //carregar dados do evento - Cancelamento
                oEvento.versao = oParam.versaoDadosEventos;
                oEvento.infEvento = (ITEventoInfEvento)Servicos.XMLFactory(oParam.versao, "TEventoInfEvento");
                //�ID� + tpEvento + chave da NF-e + nSeqEvento                
                oEvento.infEvento.Id = String.Format("ID110111{0}{1:00}", oProtNFe.infProt.chNFe, nSeqEvento);

                oEvento.infEvento.cOrgao = oParam.UF.ToCOrgaoIBGE();
                oEvento.infEvento.tpAmb = oProtNFe.infProt.tpAmb;

                oEvento.infEvento.Item = oNFe.chaveNota.Substring(9, 14);
                oEvento.infEvento.ItemElementName = ITCTypeCNPJCPF.CNPJ;
                oEvento.infEvento.chNFe = oProtNFe.infProt.chNFe;

                //Data e hora do evento no formato AAAA-MM-DDThh:mm:ssTZD 
                //(UTC - Universal Coordinated Time, onde TZD pode ser -02:00 (Fernando de Noronha), 
                //-03:00 (Bras�lia) ou -04:00 (Manaus), no hor�rio de ver�o ser�o -01:00, -02:00 e -03:00. 
                //Ex.: 2010-08-19T13:00:15-03:00.
                oEvento.infEvento.dhEvento = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzzz");

                oEvento.infEvento.tpEvento = TEventoInfEventoTpEvento.Cancelamento;
                oEvento.infEvento.nSeqEvento = nSeqEvento.ToString();
                oEvento.infEvento.verEvento = TEventoInfEventoVerEvento.Item100;
                oEvento.infEvento.detEvento = (ITEventoInfEventoDetEvento)Servicos.XMLFactory(oParam.versao, "TEventoInfEventoDetEvento");
                oEvento.infEvento.detEvento.descEvento = TEventoInfEventoDetEventoDescEvento.Cancelamento;
                oEvento.infEvento.detEvento.versao = TEventoInfEventoDetEventoVersao.Item100;

                oEvento.infEvento.detEvento.nProt = oProtNFe.infProt.nProt;
                oEvento.infEvento.detEvento.xJust = oFrm.TextResposta.Text.Trim();
                oProtNFe = null;

                //salvar na caixa de entrada
                NFe2.Business.Servicos.SalvaXML(oParam.pastaEntrada + "evtCanc" + DateTime.Now.Ticks.ToString() + ".xml", oEvento);

                String msgRet = "Pedido gerado com sucesso!";
                if (!Program.empresasHabilitadas.First(em => em.cnpj == Program.empresaSelecionada).AutomacaoHabilitada && !Program.ServicoHabilitado)
                    msgRet += " Automa��o esta desabilitada. Favor Iniciar Automa��o para enviar pedido.";

                MessageBox.Show(msgRet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                oFrm.Close();
                oFrm.Dispose();
                Conexao.DisposeManager(manager);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (oNFe.codigoSituacao != TipoSituacaoNota.Aprovada && oNFe.codigoSituacao != TipoSituacaoNota.Impressa) //aprovada ou impressa
                {
                    if (oNFe.codigoSituacao == TipoSituacaoNota.Cancelada)
                    {
                        throw new Exception("Nota j� cancelada.");
                    }
                    else
                    {
                        throw new Exception("Nota n�o foi aprovada pela SEFAZ.");
                    }
                }

                oFrm = new FrmInfNRec();
                oFrm.Text = "Carta de corre��o";
                oFrm.LabelPergunta.Text = "Informe a corre��o";
                oFrm.TextResposta.Multiline = true;
                oFrm.TextResposta.Height *= 3;


                oFrm.DoOnOkClick += new EventHandler(oFrm_DoOnOkECC_Click);
                oFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        void oFrm_DoOnOkECC_Click(object sender, EventArgs e)
        {
            ClientEnvironment manager = null;
            Parametro oParam = null;

            try
            {
                if (String.IsNullOrEmpty(oFrm.TextResposta.Text))
                    throw new Exception("Corre��o n�o foi informada.");

                manager = Conexao.CreateManager(Program.ConAux);
                oParam = Program.GetParametro(Program.empresaSelecionada, manager);


                //verificar se j� existe algum evento desse tipo registrado para a NFe
                //verificar nSeqEvento
                int nSeqEvento = oNFe.CarregarEventos(manager)
                    .Count(ev => ev.tpEvento == TEventoInfEventoTpEvento.CartaCorrecao &&
                        (ev.codigoSituacao == TipoSituacaoEvento.FinalizadoAprovado135 ||
                         ev.codigoSituacao == TipoSituacaoEvento.FinalizadoAprovado136))
                        + 1;

                ITEvento oEvento = (ITEvento)Servicos.XMLFactory(oParam.versao, "TEvento");
                ITProtNFe oProtNFe = (ITProtNFe)Servicos.CarregaXML_STR(oNFe.xmlProcesso, oNFe.versao, "TProtNFe");

                //carregar dados do evento - CCe
                oEvento.versao = oParam.versaoDadosEventos;
                oEvento.infEvento = (ITEventoInfEvento)Servicos.XMLFactory(oParam.versao, "TEventoInfEvento");
                //�ID� + tpEvento + chave da NF-e + nSeqEvento                
                oEvento.infEvento.Id = String.Format("ID110110{0}{1:00}", oProtNFe.infProt.chNFe, nSeqEvento);

                oEvento.infEvento.cOrgao = oParam.UF.ToCOrgaoIBGE();
                oEvento.infEvento.tpAmb = oProtNFe.infProt.tpAmb;

                oEvento.infEvento.Item = oNFe.empresa;
                oEvento.infEvento.ItemElementName = ITCTypeCNPJCPF.CNPJ;
                oEvento.infEvento.chNFe = oProtNFe.infProt.chNFe;

                //Data e hora do evento no formato AAAA-MM-DDThh:mm:ssTZD 
                //(UTC - Universal Coordinated Time, onde TZD pode ser -02:00 (Fernando de Noronha), 
                //-03:00 (Bras�lia) ou -04:00 (Manaus), no hor�rio de ver�o ser�o -01:00, -02:00 e -03:00. 
                //Ex.: 2010-08-19T13:00:15-03:00.
                oEvento.infEvento.dhEvento = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzzz");

                oEvento.infEvento.tpEvento = TEventoInfEventoTpEvento.CartaCorrecao;
                oEvento.infEvento.nSeqEvento = nSeqEvento.ToString();
                oEvento.infEvento.verEvento = TEventoInfEventoVerEvento.Item100;
                oEvento.infEvento.detEvento = (ITEventoInfEventoDetEvento)Servicos.XMLFactory(oParam.versao, "TEventoInfEventoDetEvento");
                oEvento.infEvento.detEvento.descEvento = TEventoInfEventoDetEventoDescEvento.CartadeCorrecao;
                oEvento.infEvento.detEvento.versao = TEventoInfEventoDetEventoVersao.Item100;
                oEvento.infEvento.detEvento.xCondUso = TEventoInfEventoDetEventoXCondUso.ACartadeCorrecaoedisciplinadapeloparagrafo1oAdoart7odoConvenioSNde15dedezembrode1970epodeserutilizadapararegularizacaodeerroocorridonaemissaodedocumentofiscaldesdequeoerronaoestejarelacionadocomIasvariaveisquedeterminamovalordoimpostotaiscomobasedecalculoaliquotadiferencadeprecoquantidadevalordaoperacaooudaprestacaoIIacorrecaodedadoscadastraisqueimpliquemudancadoremetenteoudodestinatarioIIIadatadeemissaooudesaida;
                oEvento.infEvento.detEvento.xCondUsoSpecified = true;

                oEvento.infEvento.detEvento.xCorrecao = oFrm.TextResposta.Text.Trim();
                oProtNFe = null;

                //salvar na caixa de entrada
                NFe2.Business.Servicos.SalvaXML(oParam.pastaEntrada + "CCe" + DateTime.Now.Ticks.ToString() + ".xml", oEvento);

                String msgRet = "Pedido gerado com sucesso!";
                if (!Program.empresasHabilitadas.First(em => em.cnpj == Program.empresaSelecionada).AutomacaoHabilitada && !Program.ServicoHabilitado)
                    msgRet += " Automa��o esta desabilitada. Favor Iniciar Automa��o para enviar pedido.";

                MessageBox.Show(msgRet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                oFrm.Close();
                oFrm.Dispose();
                Conexao.DisposeManager(manager);
            }
        }


        //arquivo de aprova��o

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                sfdProcNFe.Filter = "Arquivo XML|*.xml";
                sfdProcNFe.Title = "Salvar arquivo";
                sfdProcNFe.FileName = oNFe.nProt + "_v2.00-procNFe.xml";
                sfdProcNFe.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void sfdProcNFe_FileOk(object sender, CancelEventArgs e)
        {
            ClientEnvironment manager = null;
            Parametro oParam = null;

            try
            {
                manager = Conexao.CreateManager(Program.ConAux);
                oParam = Program.GetParametro(Program.empresaSelecionada, manager);


                if (oNFe.codigoSituacao != TipoSituacaoNota.Aprovada
                    && oNFe.codigoSituacao != TipoSituacaoNota.Impressa
                    && oNFe.codigoSituacao != TipoSituacaoNota.Cancelada
                    && oNFe.codigoSituacao != TipoSituacaoNota.Denegada) // aprovada ou impressa ou cancelada ou denegada
                {
                    throw new Exception("Somente para notas Aprovadas, Denegadas ou Canceladas!");
                }

                if (oNFe.codigoSituacao == TipoSituacaoNota.Cancelada)
                {
                    MessageBox.Show("Aten��o!!! Para gerar o arquivo de processo do cancelamento, utilize o comando Gerar procCancNFe na aba Cancelamento.");
                }

                NFeUtils.GeraArquivoProcNFe(oNFe, sfdProcNFe.FileName, oParam.versaoDados);
                MessageBox.Show("Arquivo gerado com sucesso em : " + sfdProcNFe.FileName);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                oParam = null;
                Conexao.DisposeManager(manager);
            }

        }


        //arquivo de cancelamento

        private void button4_Click(object sender, EventArgs e)
        {
            ClientEnvironment manager = null;
            try
            {
                if (oNFe.codigoSituacao != TipoSituacaoNota.Cancelada)
                {
                    throw new Exception("Nota n�o esta cancelada.");
                }

                sfdProcCancNFe.Filter = "Arquivo XML|*.xml";
                sfdProcCancNFe.Title = "Salvar arquivo";

                manager = Conexao.CreateManager(Program.ConAux);

                //verficar se foi cancelado por evento
                if (oNFe.CanceladaPorEvento(manager))
                {
                    //se cancelada por evento, dever� gerar o arquivo de divulga��o do evento
                    throw new Exception("Nota foi cancelada por evento. N�o � poss�vel gerar esse arquivo.");
                }
                sfdProcCancNFe.FileName = oNFe.nProtCancelamento + "_v2.00-procCancNFe.xml";
                sfdProcCancNFe.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.DisposeManager(manager);
            }
        }

        private void sfdProcCancNFe_FileOk(object sender, CancelEventArgs e)
        {
            ClientEnvironment manager = null;
            Parametro oParam = null;


            try
            {
                manager = Conexao.CreateManager(Program.ConAux);
                oParam = Program.GetParametro(Program.empresaSelecionada, manager);


                if (oNFe.codigoSituacao != TipoSituacaoNota.Aprovada
                    && oNFe.codigoSituacao != TipoSituacaoNota.Impressa
                    && oNFe.codigoSituacao != TipoSituacaoNota.Cancelada) // aprovada ou impressa ou cancelada
                {
                    throw new Exception("Somente para notas Aprovadas ou Canceladas!");
                }

                NFeUtils.GeraArquivoProcCancNFe(oNFe, sfdProcCancNFe.FileName, oParam.versaoDados);
                MessageBox.Show("Arquivo gerado com sucesso em : " + sfdProcCancNFe.FileName);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                oParam = null;
                Conexao.DisposeManager(manager);
            }

        }

        private void btAtualizarTela_Click(object sender, EventArgs e)
        {
            DoRefresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClientEnvironment manager = null;
            Parametro oParam = null;
            try
            {
                manager = Conexao.CreateManager(Program.ConAux);
                oParam = Program.GetParametro(Program.empresaSelecionada, manager);

                if (oNFe.codigoSituacao == TipoSituacaoNota.Cancelada)
                {
                    //verificar se foi cancelada por evento
                    if (oNFe.CanceladaPorEvento(manager))
                    {
                        #region cancelamento por evento
                        MessageBox.Show("Nota cancelada por evento");
                        #endregion
                    }
                    else
                    {
                        #region cancelamento por webservice
                        //tratar envio de xml para destinat�rio.
                        String nomeArquivo = oNFe.nProtCancelamento + "_v2.00-procCancNFe.xml";

                        //enviar email para destinat�rio ?
                        ITNFe oNFeXML = (ITNFe)Servicos.CarregaXML_STR(oNFe.xmlNota, oNFe.versao, "TNFe");
                        if (!String.IsNullOrEmpty(oNFeXML.infNFe.dest.email))
                        {
                            if (File.Exists(oParam.pastaImpressao + nomeArquivo.Replace(".xml", ".txt")))
                                File.Delete(oParam.pastaImpressao + nomeArquivo.Replace(".xml", ".txt"));

                            //gerar arquivo TXT com o email do destinat�rio
                            using (StreamWriter oSW = File.CreateText(oParam.pastaImpressao + nomeArquivo.Replace(".xml", ".txt")))
                            {
                                oSW.WriteLine(oNFeXML.infNFe.dest.email);
                                oSW.WriteLine(oNFeXML.infNFe.Id.Replace("NFe", ""));
                                oSW.WriteLine(oNFeXML.infNFe.ide.nNF);
                                oSW.WriteLine(oNFeXML.infNFe.ide.serie);
                                oSW.WriteLine(oNFeXML.infNFe.emit.xNome);
                                oSW.WriteLine(oNFe.nProtCancelamento);
                                oSW.WriteLine(oNFeXML.infNFe.dest.xNome);
                                oSW.Close();
                            }
                            GC.Collect();

                            //gerar arquivo txt com o email do destinat�rio
                            NFeUtils.GeraArquivoProcCancNFe(oNFe, oParam.pastaImpressao + nomeArquivo, oParam.versaoDados);

                            MessageBox.Show("Arquivo enviado para servidor de impress�o.");

                        }
                        else
                        {
                            MessageBox.Show("N�o existe email para enviar arquivo.");
                        }
                        oNFeXML = null;
                        #endregion
                    }
                }
                else
                {
                    MessageBox.Show("Nota n�o esta cancelada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                oParam = null;
                Conexao.DisposeManager(manager);
            }
        }

        private void dgvEventos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }






    }
}