using UnityEngine;

namespace Entities
{
    public class Caracteristicas
    {
        [SerializeField]
        public SexoEnum Sexo = SexoEnum.Masculino;
        [SerializeField]
        public AlturaEnum Altura  = AlturaEnum.Alto;
        [SerializeField]
        public DeficienciaEnum Deficiencia  = DeficienciaEnum.SemDeficiencia;
        [SerializeField]
        public PreferenciaSexualEnum Preferencia  = PreferenciaSexualEnum.Heterosexual;
        [SerializeField]
        public FaixaEtariaEnum FaixaEtaria  = FaixaEtariaEnum.Adulto;

        [SerializeField]
        public CorDaPeleEtniaEnum CorDaPeleEtnia  = CorDaPeleEtniaEnum.Branca;

        [SerializeField]
        public FinaceiroEnum Finaceiro = FinaceiroEnum.Rico;
    }
}