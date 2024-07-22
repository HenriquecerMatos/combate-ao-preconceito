using Assets.Scripts.Extencions;
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

        [SerializeField]
        public ReligiaoEnum Religiao = ReligiaoEnum.Nenhuma;

        [SerializeField]
        public BiosferaEnum Biosfera = BiosferaEnum.Op1;

        [SerializeField]
        public RelacoesEnum Relacoes = RelacoesEnum.Op1;

        public float ValorCalculadoApartirDasCaracteisticas(float entrada)
        {
            var pesoTotal = ValorPeso();

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


        /// <summary>
        /// usado na hora de mostrar o histórico
        /// </summary>
        /// <returns></returns>
        public string Descrever()
        {
            return Sexo.ValorDescription() + ", " + Altura.ValorDescription() +
            ", " + Deficiencia.ValorDescription() + ", " + Preferencia.ValorDescription() +
            ", " + FaixaEtaria.ValorDescription() + ", " + CorDaPeleEtnia.ValorDescription() +
            ", " + Financeiro.ValorDescription() +
            ", " + Religiao.ValorDescription() +
            ", " + Relacoes.ValorDescription()+
            ", " + Biosfera.ValorDescription();
        }

        /// <summary>
        /// para calcular 
        /// </summary>
        /// <returns></returns>
        public float ValorPeso()
        {
            return Sexo.ValorPeso()
            + Altura.ValorPeso()
            + Deficiencia.ValorPeso()
            + Preferencia.ValorPeso()
            + FaixaEtaria.ValorPeso()
            + CorDaPeleEtnia.ValorPeso()
            + Financeiro.ValorPeso()
            + Religiao.ValorPeso();
        }
    }
}