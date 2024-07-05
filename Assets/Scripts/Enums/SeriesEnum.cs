
using Assets.Scripts.Extencions;
using System.ComponentModel;


public enum TipoAtividadeEnum
{
    [Description("Não Definida")]
    NaoDefinida,
    [Description("Eventos")]//esportivos, religiosos, cívicos, regionais
    Eventos,
    [Description("Exames e Provas")] 
    ExamesProvas,
    [Description("Dilemas")]//envolvendo escolhas pessoais
    Dilemas,
    [Description("Oportunidades e Desafios")]
    OportunidadesDesafios,
    [Description("Aquisições")]
    Aquisicoes,
    [Description("Perdas")]
    Perdas
}


public enum SeriesEnum
{
    Serie6,
    Serie7,
    Serie8,
    Ano1,
    Ano2,
    Ano3,
    Ano1_faculdade,
    Ano2_faculdade,
    Ano3_faculdade,
    Ano4_faculdade,
    Ano5_faculdade,
    Aprendiz,
    Tecnico,
    Chefia,
    Gerente,
    Executivo,
    Mestrado,
    Doutorado,
    CEO
}

public enum DificuldadeEnum
{
    Facil,
    Medio,
    dificil
}

public enum PanelEnum
{
    Serie,
    Dificuldade,
    Jogo,
    PerguntaResposta,
    Resultado,
}



/// <summary>
/// Sexo biológico
/// </summary>
public enum SexoEnum
{
    [Description("Homem"), Dificuldade(DificuldadeEnum.Facil), Peso(0f)] //0%
    Masculino,
    [Description("Mulher"), Dificuldade(DificuldadeEnum.Medio), Peso(0.05f)] //5%
    Feminino
}

/// <summary>
/// Altura do individuo
/// </summary>
public enum AlturaEnum
{
    [Description("Baixo"), Dificuldade(DificuldadeEnum.dificil), Peso(0.03f)] //3%
    Baixo,
    [Description("Normal"), Dificuldade(DificuldadeEnum.Medio), Peso(0f)] //0%
    Normal,
    [Description("Alto"), Dificuldade(DificuldadeEnum.Facil), Peso(-0.03f)] //+3% // fator facilitador
    Alto
}

/// <summary>
/// Se tem alguma deficiaencia
/// </summary>
public enum DeficienciaEnum
{
    [Description("Sem Deficiência"), Dificuldade(DificuldadeEnum.Facil), Peso(0f)] //0%
    SemDeficiencia,
    [Description("Deficiência Física"), Dificuldade(DificuldadeEnum.Medio), Peso(0.08f)]  //8%
    PCDF,
    [Description("Deficiência Intelectual"), Dificuldade(DificuldadeEnum.dificil), Peso(0.12f)] //12%
    PCDI,
    [Description("Deficiência Física e Intelectual"), Dificuldade(DificuldadeEnum.dificil), Peso(0.20f)] // 20%
    PCDFI
}

/// <summary>
/// Preferencia Sexual
/// </summary>
public enum PreferenciaSexualEnum
{
    [Description("Heterosexual"), Dificuldade(DificuldadeEnum.Facil), Peso(0f)] //0%
    Heterosexual,
    [Description("LGBTQI+"), Dificuldade(DificuldadeEnum.dificil), Peso(0.04f)] //4%
    LGBTQI,
    [Description("Assexual"), Dificuldade(DificuldadeEnum.dificil), Peso(0.03f)] //3%
    Assexual
}

/// <summary>
/// Faixa Etária
/// </summary>
public enum FaixaEtariaEnum
{
    [Description("Muito Jovem"), Dificuldade(DificuldadeEnum.dificil), Peso(0.05f)] //5%
    MuitoJovem,
    [Description("Jovem"), Dificuldade(DificuldadeEnum.Medio), Peso(0.02f)] //2%
    Jovem,
    [Description("Adulto"), Dificuldade(DificuldadeEnum.Facil), Peso(0f)] //0%
    Adulto,
    [Description("Idoso"), Dificuldade(DificuldadeEnum.dificil), Peso(0.06f)] //6%
    Idoso
}

/// <summary>
/// Cor Da Pele ou Etnia
/// </summary>
public enum CorDaPeleEtniaEnum
{
    [Description("Branca"), Dificuldade(DificuldadeEnum.Facil), Peso(0f)] //0%
    Branca,
    [Description("Amarela"), Dificuldade(DificuldadeEnum.Facil), Peso(0f)] //0%
    Amarela,
    [Description("Albina"), Dificuldade(DificuldadeEnum.Medio), Peso(0.025f)] //2,5%
    Albina,
    [Description("Parda"), Dificuldade(DificuldadeEnum.Facil), Peso(0.015f)] //1,5%
    Parda,
    [Description("Indígena"), Dificuldade(DificuldadeEnum.Facil), Peso(0.01f)]  //1%
    Indigina,
    [Description("Negra"), Dificuldade(DificuldadeEnum.dificil), Peso(0.05f)] //5%
    Negra,
}

/// <summary>
/// Tipo Físico do individuo
/// </summary>
public enum TipoFisicoEnum
{
    [Description("Normal"), Dificuldade(DificuldadeEnum.Facil), Peso(0f)] //0%
    Normal,
    [Description("Magra"), Dificuldade(DificuldadeEnum.Medio), Peso(0.005f)] //0,5%
    Magra,
    [Description("Obesa"), Dificuldade(DificuldadeEnum.dificil), Peso(0.03f)] //3%
    Obesa,
}

/// <summary>
/// vida financeira
/// </summary>
public enum FinanceiroEnum
{
   
    [Description("Media"), Dificuldade(DificuldadeEnum.Medio), Peso(0f)] //0%
    Media,
    [Description("Rico"), Dificuldade(DificuldadeEnum.Facil), Peso(-0.1f)] //+10% // fator facilitador
    Rico,
    [Description("Pobre"), Dificuldade(DificuldadeEnum.dificil), Peso(0.025f)] //2,5%
    Pobre,
    [Description("Miserável"), Dificuldade(DificuldadeEnum.dificil), Peso(0.08f)] //8%
    Miseravel,
}

