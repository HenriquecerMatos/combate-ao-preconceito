
using Assets.Scripts.Extencions;
using System.ComponentModel;

public enum SeriesEnum
{
    Serie6 = 0,
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
    [Description("Mulher"), Dificuldade(DificuldadeEnum.Medio), Peso(0.1f)] //10%
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
    [Description("Alto"), Dificuldade(DificuldadeEnum.Facil), Peso(-0.03f)] //+3%
    Alto
}

/// <summary>
/// Se tem alguma deficiaencia
/// </summary>
public enum DeficienciaEnum
{
    [Description("Sem Deficiência"), Dificuldade(DificuldadeEnum.Facil), Peso(0f)] //0%
    SemDeficiencia,
    [Description("Deficiência Física"), Dificuldade(DificuldadeEnum.Medio), Peso(0.13f)]  //13%
    PCDF,
    [Description("Deficiência Intelectual"), Dificuldade(DificuldadeEnum.dificil), Peso(0.18f)] //18%
    PCDI,
    [Description("Deficiência Física e Intelectual"), Dificuldade(DificuldadeEnum.dificil), Peso(0.25f)] // 25%
    PCDFI
}

/// <summary>
/// Preferencia Sexual
/// </summary>
public enum PreferenciaSexualEnum
{
    [Description("Heterosexual"), Dificuldade(DificuldadeEnum.Facil), Peso(0f)] //0%
    Heterosexual,
    [Description("LGBTQI+"), Dificuldade(DificuldadeEnum.dificil), Peso(0.05f)] //5%
    LGBTQI,
    [Description("Assexual"), Dificuldade(DificuldadeEnum.dificil), Peso(0.05f)] //5%
    Assexual
}

/// <summary>
/// Faixa Etária
/// </summary>
public enum FaixaEtariaEnum
{
    [Description("Muito Jovem"), Dificuldade(DificuldadeEnum.dificil), Peso(0.07f)] //7%
    MuitoJovem,
    [Description("Jovem"), Dificuldade(DificuldadeEnum.Medio), Peso(0.05f)] //5%
    Jovem,
    [Description("Adulto"), Dificuldade(DificuldadeEnum.Facil), Peso(0f)] //0%
    Adulto,
    [Description("Idoso"), Dificuldade(DificuldadeEnum.dificil), Peso(0.07f)] //7%
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
    [Description("Albina"), Dificuldade(DificuldadeEnum.Medio), Peso(0.05f)] //5%
    Albina,
    [Description("Parda"), Dificuldade(DificuldadeEnum.Facil), Peso(0.03f)] //3%
    Parda,
    [Description("Indígena"), Dificuldade(DificuldadeEnum.Facil), Peso(0.025f)]  //2,5%
    Indigina,
    [Description("Negra"), Dificuldade(DificuldadeEnum.dificil), Peso(0.08f)] //8%
    Negra,
}

/// <summary>
/// Tipo Físico do individuo
/// </summary>
public enum TipoFisicoEnum
{
    [Description("Normal"), Dificuldade(DificuldadeEnum.Facil), Peso(0f)] //0%
    Normal,
    [Description("Magra"), Dificuldade(DificuldadeEnum.Medio), Peso(0.03f)] //3%
    Magra,
    [Description("Obesa"), Dificuldade(DificuldadeEnum.dificil), Peso(0.09f)] //9%
    Obesa,
}

/// <summary>
/// vida financeira
/// </summary>
public enum FinaceiroEnum
{
    [Description("Miserável"), Dificuldade(DificuldadeEnum.dificil), Peso(0.1f)] //10%
    Miseravel,
    [Description("Pobre"), Dificuldade(DificuldadeEnum.dificil), Peso(0.05f)] //5%
    Pobre,
    [Description("Media"), Dificuldade(DificuldadeEnum.Medio), Peso(0f)] //0%
    Media,
    [Description("Rico"), Dificuldade(DificuldadeEnum.Facil), Peso(-1f)] //+10%
    Rico,
}

