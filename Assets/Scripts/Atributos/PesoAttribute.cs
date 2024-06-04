using System;

namespace Assets.Scripts.Extencions
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PesoAttribute : Attribute
    {
        public float Valor { get; } = 0;

        public PesoAttribute(float valor)
        {
            Valor = valor;
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DificuldadeAttribute : Attribute
    {
        public int Valor { get; } = 0;

        public DificuldadeAttribute(int valor)
        {
            Valor = valor;
        }

        public DificuldadeAttribute(DificuldadeEnum valor)
        {
            Valor = (int)valor;
        }
    }
}
