using UnityEngine;

namespace Entities
{
    public class Caracteristicas
    {
        [SerializeField]
        public SexoEnum Sexo { get; set; } = SexoEnum.Masculino;
        [SerializeField]
        public AlturaEnum Altura { get; set; } = AlturaEnum.Alto;
        [SerializeField]
        public DeficienciaEnum Deficiencia { get; set; } = DeficienciaEnum.SemDeficiencia;
        [SerializeField]
        public PreferenciaSexualEnum Preferencia { get; set; } = PreferenciaSexualEnum.Heterosexual;
        [SerializeField]
        public FaixaEtariaEnum FaixaEtaria { get; set; } = FaixaEtariaEnum.Adulto;

        [SerializeField]
        public CorDaPeleEtniaEnum CorDaPeleEtnia { get; set; } = CorDaPeleEtniaEnum.Branca;

        [SerializeField]
        public FinaceiroEnum Finaceiro { get; set; } = FinaceiroEnum.Rico;
    }
}