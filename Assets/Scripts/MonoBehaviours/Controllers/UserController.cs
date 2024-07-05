using Assets.Scripts.Extencions;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class UserController : MonoBehaviour
{

    private readonly string PastaHistorico = "historico";

    [SerializeField]
    public SeriesEnum Serie;
    [SerializeField]
    public DificuldadeEnum Dificuldade;

    public float Pontuacao=0;

    public ListaRespostasDadas RespostasAcumuladasDaPartida = new();
    public List<ListaRespostasDadas> HistoricoResposta;

    [SerializeField]
    public Caracteristicas Caracteristicas{get;set;} = new Caracteristicas();

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
        RespostasAcumuladasDaPartida.Caracteristicas = Caracteristicas;
    }
    #endregion

    #region Historico
    public void SalvarArquivoHistorico()
    {
        string filePath = Path.Combine(Application.persistentDataPath, PastaHistorico, DateTime.Now.Ticks + ".json");
        if (RespostasAcumuladasDaPartida.listaPerguntasRespostas.Count() > 0)
        {
            File.WriteAllText(filePath, JsonUtility.ToJson(RespostasAcumuladasDaPartida));
        }
    }

    public void LerArquivosHistorico()
    {
        string caminhoCompleto = Path.Combine(Application.persistentDataPath, PastaHistorico);

        if (Directory.Exists(caminhoCompleto))
        {
            string[] arquivos = Directory.GetFiles(caminhoCompleto);

            foreach (string arquivo in arquivos)
            {
                Debug.Log("Arquivo encontrado: " + arquivo);
                try
                {
                    var noHistorico = JsonUtility.FromJson<ListaRespostasDadas>(arquivo);
                    HistoricoResposta.Add(noHistorico);
                }
                catch (Exception)
                {
                    Debug.Log("Erro de leitura");//throw;
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
