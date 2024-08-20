using Assets.Scripts.Extencions;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// script responsável por criar o menu na tela "ConfiguracaoUser"
/// </summary>
public class UIMenuConfigUser : BaseController
{
    public GameObject MenuClone;
    public List<Transform> Menus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BuscarSetarUsuario();
        CriarMenuSexo();
        CriarMenuAltura();
        //FinaceiroEnum
        CriarMenuFinanceiro();
        //CorDaPeleEtniaEnum
        CriarMenuCorDaPeleEtnia();
        //FaixaEtariaEnum
        CriarMenuFaixaEtaria();
        //PreferenciaSexualEnum
        CriarMenuPreferenciaSexual();
        //DeficienciaEnum
        CriarMenuDeficiencia();

        CriarMenuReligiao();

        #region caracteristicas voltadas a seleção de perguntas
        CriarMenuBiosfera();
        CriarMenuRelacoes();
        #endregion

        MenuClone.SetActive(false);
    }

    public void CriarMenuBiosfera()
    {
        var dicionario = EnumExtension.ToDictionaryIntString<BiosferaEnum>();
        var listaBtnCriados = ListaDeBtsCriados<BiosferaEnum>(dicionario, "Religiao (onde alt):", (int)UserController.Caracteristicas.Biosfera);

        var chaves = dicionario.Keys.ToList(); // Obtemos uma lista das chaves
        for (int i = 0; i < chaves.Count; i++)
        {
            int key = chaves[i];
            string valor = dicionario[key];

            var btn = listaBtnCriados[i];

            btn.onClick.AddListener(
                () =>
                {
                    UserController.Caracteristicas.Biosfera = (BiosferaEnum)key;
                    Debug.Log(valor);
                });
        }
    }

    public void CriarMenuRelacoes()
    {
        var dicionario = EnumExtension.ToDictionaryIntString<RelacoesEnum>();
        var listaBtnCriados = ListaDeBtsCriados<RelacoesEnum>(dicionario, "Religiao (onde alt):", (int)UserController.Caracteristicas.Relacoes);

        var chaves = dicionario.Keys.ToList(); // Obtemos uma lista das chaves
        for (int i = 0; i < chaves.Count; i++)
        {
            int key = chaves[i];
            string valor = dicionario[key];

            var btn = listaBtnCriados[i];

            btn.onClick.AddListener(
                () =>
                {
                    UserController.Caracteristicas.Relacoes = (RelacoesEnum)key;
                    Debug.Log(valor);
                });
        }
    }

    public void CriarMenuReligiao()
    {
        var dicionario = EnumExtension.ToDictionaryIntString<ReligiaoEnum>();
        var listaBtnCriados = ListaDeBtsCriados<ReligiaoEnum>(dicionario, "Religiao (onde alt):", (int)UserController.Caracteristicas.Religiao);

        var chaves = dicionario.Keys.ToList(); // Obtemos uma lista das chaves
        for (int i = 0; i < chaves.Count; i++)
        {
            int key = chaves[i];
            string valor = dicionario[key];

            var btn = listaBtnCriados[i];

            btn.onClick.AddListener(
                () =>
                {
                    UserController.Caracteristicas.Religiao = (ReligiaoEnum)key;
                    Debug.Log(valor);
                });
        }
    }

    public void CriarMenuDeficiencia()
    {
        var dicionario = EnumExtension.ToDictionaryIntString<DeficienciaEnum>();
        var listaBtnCriados = ListaDeBtsCriados<DeficienciaEnum>(dicionario, "Deficiência:", (int)UserController.Caracteristicas.Deficiencia);

        var chaves = dicionario.Keys.ToList(); // Obtemos uma lista das chaves
        for (int i = 0; i < chaves.Count; i++)
        {
            int key = chaves[i];
            string valor = dicionario[key];

            var btn = listaBtnCriados[i];

            btn.onClick.AddListener(
                () =>
                {
                    UserController.Caracteristicas.Deficiencia = (DeficienciaEnum)key;
                    Debug.Log(valor);
                });
        }
    }
    public void CriarMenuCorDaPeleEtnia()
    {
        var dicionario = EnumExtension.ToDictionaryIntString<CorDaPeleEtniaEnum>();
        var listaBtnCriados = ListaDeBtsCriados<CorDaPeleEtniaEnum>(dicionario, "Cor Da Pele/Etnia:", (int)UserController.Caracteristicas.CorDaPeleEtnia);

        var chaves = dicionario.Keys.ToList(); // Obtemos uma lista das chaves
        for (int i = 0; i < chaves.Count; i++)
        {
            int key = chaves[i];
            string valor = dicionario[key];

            var btn = listaBtnCriados[i];

            btn.onClick.AddListener(
                () =>
                {
                    UserController.Caracteristicas.CorDaPeleEtnia = (CorDaPeleEtniaEnum)key;
                    Debug.Log(valor);
                });
        }
    }
    public void CriarMenuFaixaEtaria()
    {
        var dicionario = EnumExtension.ToDictionaryIntString<FaixaEtariaEnum>();
        var listaBtnCriados = ListaDeBtsCriados<FaixaEtariaEnum>(dicionario, "Faixa Etária:", (int)UserController.Caracteristicas.FaixaEtaria);

        var chaves = dicionario.Keys.ToList(); // Obtemos uma lista das chaves
        for (int i = 0; i < chaves.Count; i++)
        {
            int key = chaves[i];
            string valor = dicionario[key];

            var btn = listaBtnCriados[i];

            btn.onClick.AddListener(
                () =>
                {
                    UserController.Caracteristicas.FaixaEtaria = (FaixaEtariaEnum)key;
                    Debug.Log(valor);
                });
        }
    }

    public void CriarMenuPreferenciaSexual()
    {
        var dicionario = EnumExtension.ToDictionaryIntString<PreferenciaSexualEnum>();
        var listaBtnCriados = ListaDeBtsCriados<PreferenciaSexualEnum>(dicionario, "Preferencia Sexual:", (int)UserController.Caracteristicas.Preferencia);

        var chaves = dicionario.Keys.ToList(); // Obtemos uma lista das chaves
        for (int i = 0; i < chaves.Count; i++)
        {
            int key = chaves[i];
            string valor = dicionario[key];

            var btn = listaBtnCriados[i];

            btn.onClick.AddListener(
                () =>
                {
                    UserController.Caracteristicas.Preferencia = (PreferenciaSexualEnum)key;
                    Debug.Log(valor);
                });
        }
    }

    public void CriarMenuFinanceiro()
    {
        var dicionario = EnumExtension.ToDictionaryIntString<FinanceiroEnum>();
        var listaBtnCriados = ListaDeBtsCriados<FinanceiroEnum>(dicionario, "Financeiro:", (int)UserController.Caracteristicas.Financeiro);

        var chaves = dicionario.Keys.ToList(); // Obtemos uma lista das chaves
        for (int i = 0; i < chaves.Count; i++)
        {
            int key = chaves[i];
            string valor = dicionario[key];

            var btn = listaBtnCriados[i];

            btn.onClick.AddListener(
                () =>
                {
                    UserController.Caracteristicas.Financeiro = (FinanceiroEnum)key;
                    Debug.Log(valor);
                });
        }
    }
    public void CriarMenuAltura()
    {
        var dicionario = EnumExtension.ToDictionaryIntString<AlturaEnum>();
        var listaBtnCriados = ListaDeBtsCriados<AlturaEnum>(dicionario, "Altura:", (int)UserController.Caracteristicas.Altura);

        var chaves = dicionario.Keys.ToList(); // Obtemos uma lista das chaves
        for (int i = 0; i < chaves.Count; i++)
        {
            int key = chaves[i];
            string valor = dicionario[key];

            var btn = listaBtnCriados[i];

            btn.onClick.AddListener(
                () =>
                {
                    UserController.Caracteristicas.Altura = (AlturaEnum)key;
                    Debug.Log(valor);
                });
        }
    }

    public void CriarMenuSexo()
    {
        //cria um dicionário 
        var dicionario = EnumExtension.ToDictionaryIntString<SexoEnum>();

        //cria o menu de acordo com o dicionário/enum e da um titulo 
        var listaBtnCriados = ListaDeBtsCriados<SexoEnum>(dicionario, "Sexo:", (int)UserController.Caracteristicas.Sexo);

        var chaves = dicionario.Keys.ToList(); // Obtemos uma lista das chaves
        for (int i = 0; i < chaves.Count; i++)
        {
            int key = chaves[i];
            string valor = dicionario[key];

            var btn = listaBtnCriados[i];

            btn.onClick.AddListener(
                () =>
                {
                    UserController.Caracteristicas.Sexo = (SexoEnum)key;
                    //Debug.Log(valor);
                });
        }
    }

    public List<Button> ListaDeBtsCriados<TEnum>(Dictionary<int, string> dicionario, string nomeInput, int valorCaracteristica) where TEnum : Enum
    {
        List<Button> ret = new List<Button>();
        var clone = CriarPainel();
        Menus.Add(clone.transform);
        //pega o menu criado
        var Menu = clone.GetComponent<PainelMenuBaseConfigUser>();
        foreach (var item in dicionario)
        {

            var novoBotao = Instantiate(Menu.ButtonBase);

            //acha o painel pai
            var painelPai = Menu.ButtonBase.transform.GetComponentInParent<UiMultOptions>();

            var rectBtn = novoBotao.GetComponent<RectTransform>();

            painelPai.CriarElemento(rectBtn);


            //reposiciona o parentesco
            novoBotao.transform.SetParent(Menu.ButtonBase.GetComponentInParent<Transform>());
            novoBotao.transform.localScale = Vector3.one;
            //Menu.ButtonBase.gameObject.SetActive(false);
            novoBotao.gameObject.SetActive(true);
            //UiMultOptions painelPai.GetComponent<UiMultOptions>();

            novoBotao.GetComponentInChildren<TMP_Text>().text = item.Value;
            ret.Add(novoBotao);

            //colocar o valor da característica selecionada

            if (item.Key == valorCaracteristica)
            {
                painelPai.SetarResposta(rectBtn);
            }

        }
        Menu.SetLabel(nomeInput);

        return ret;
    }

    public GameObject CriarPainel()
    {
        // Instancia um clone do objeto
        GameObject clone = Instantiate(MenuClone);
        // Define o objeto clonado como filho do objeto pai
        clone.transform.SetParent(transform);
        clone.transform.localScale = Vector3.one;

        //ativa o elemento
        clone.SetActive(true);

        return clone;

    }
}
