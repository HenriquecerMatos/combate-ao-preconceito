using Assets.Scripts.Extencions;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class UserController : MonoBehaviour
{

    private readonly string PrefixoArquivoHistorico = "historico_";

    [SerializeField]
    public SeriesEnum Serie;
    [SerializeField]
    public DificuldadeEnum Dificuldade;

    public float Pontuacao = 0;

    public ListaRespostasDadas RespostasAcumuladasDaPartida = new();
    public List<ListaRespostasDadas> HistoricoResposta;

    [SerializeField]
    public Caracteristicas Caracteristicas { get; set; } = new Caracteristicas();

    public static UserController Instance { get; private set; }
    void Awake()
    {

        // Impede que o objeto seja destruído ao carregar uma nova cena
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LerArquivosHistorico();
    }

    public void SetSerie(SeriesEnum serie)
    {
        Serie = serie;
        Debug.Log(serie.ToString());
    }

    public void SetDificuldade(DificuldadeEnum dificuldade)
    {
        Dificuldade = dificuldade;
        Debug.Log(dificuldade.ValorDescription() + "-" + dificuldade.ValorPeso());
    }

    #region pontuação
    public void CalcularPontuacao(RespostaSelecionada resposta)
    {
        var valorCalculado = Caracteristicas.ValorCalculadoApartirDasCaracteisticas(resposta.Valor);
        Pontuacao += valorCalculado;
        RespostasAcumuladasDaPartida.listaPerguntasRespostas.Add(resposta);

        //pensando em uma provável alteração onde a pessoa possa mudar alguma característica ao longo do jogo vou deixar essa linha aqui 
        //normalmente ela ficaria no starUp 
        //RespostasAcumuladasDaPartida.Caracteristicas = Caracteristicas;
    }
    #endregion

    #region Historico
    public void SalvarArquivoHistorico()
    {
        string filePath = Path.Combine(Application.persistentDataPath, PrefixoArquivoHistorico + DateTime.Now.Ticks + ".json");
        if (RespostasAcumuladasDaPartida.listaPerguntasRespostas.Count() > 0)
        {
            RespostasAcumuladasDaPartida.Caracteristicas = Caracteristicas.Descrever();
            RespostasAcumuladasDaPartida.Peso=Caracteristicas.ValorPeso();
            File.WriteAllText(filePath, JsonUtility.ToJson(RespostasAcumuladasDaPartida));
        }
    }

    public void LerArquivosHistorico()
    {
        HistoricoResposta.Clear();

        string caminhoCompleto = Path.Combine(Application.persistentDataPath);

        if (Directory.Exists(caminhoCompleto))
        {
            string[] arquivos = Directory.GetFiles(caminhoCompleto);

            foreach (string arquivo in arquivos)
            {
                if (arquivo.Contains(PrefixoArquivoHistorico))
                {
                    try
                    {
                        string conteudoArquivo = File.ReadAllText(arquivo);
                        var noHistorico = JsonUtility.FromJson<ListaRespostasDadas>(conteudoArquivo);
                        HistoricoResposta.Add(noHistorico);
                    }
                    catch (Exception)
                    {
                        Debug.Log("Erro de leitura");//throw;
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("A pasta não existe ou está vazia.");
        }
    }
    #endregion
}
