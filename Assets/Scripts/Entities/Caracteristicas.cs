﻿using Assets.Scripts.Extencions;
using UnityEngine;

namespace Entities
{
    [SerializeField]
    public class Caracteristicas
    {
        [SerializeField]
        public SexoEnum Sexo = SexoEnum.Masculino;
        [SerializeField]
        public AlturaEnum Altura = AlturaEnum.Alto;
        [SerializeField]
        public DeficienciaEnum Deficiencia = DeficienciaEnum.SemDeficiencia;
        [SerializeField]
        public PreferenciaSexualEnum Preferencia = PreferenciaSexualEnum.Heterosexual;
        [SerializeField]
        public FaixaEtariaEnum FaixaEtaria = FaixaEtariaEnum.Adulto;

        [SerializeField]
        public CorDaPeleEtniaEnum CorDaPeleEtnia = CorDaPeleEtniaEnum.Branca;

        [SerializeField]
        public FinanceiroEnum Financeiro = FinanceiroEnum.Rico;

        public float ValorCalculadoApartirDasCaracteisticas(float entrada)
        {
            var pesoTotal = Sexo.ValorPeso();
            pesoTotal += Altura.ValorPeso();
            pesoTotal += Deficiencia.ValorPeso();
            pesoTotal += Preferencia.ValorPeso();
            pesoTotal += FaixaEtaria.ValorPeso();
            pesoTotal += CorDaPeleEtnia.ValorPeso();
            pesoTotal += Financeiro.ValorPeso();

            Debug.Log("entrada:" + entrada + "peso" + pesoTotal + "");

            //se a resposta tiver valor 0 não é necessário calcular
            if (entrada == 0)
            {
                return entrada;
            }
            else if (entrada > 0)//se entrada maior q 0 calcula de acordo com o peso
            {
                return entrada + (entrada * (pesoTotal) * -1);
            }
            else
            {
                return entrada - (entrada * (pesoTotal) * -1);
            }
        }
    }
}