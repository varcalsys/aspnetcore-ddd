using System;

namespace NucleoCompartilhado.Models.BaseObjects
{
    public abstract class Entidade
    {
        public int Id { get; protected set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; protected set; }


        protected Entidade()
        {
            DataCadastro = DateTime.Now;
        }

        public virtual void Ativar()
        {
            Ativo = true;
        }

        public virtual void Desativar()
        {
            Ativo = false;
        }


        #region Overrides
        public override bool Equals(object entity)
        {
            var entityTmp = entity as Entidade;

            if (ReferenceEquals(entityTmp, null))
                return false;

            if (ReferenceEquals(this, entityTmp))
                return true;

            if (GetType() != entityTmp.GetType())
                return false;

            if (Id == 0 || entityTmp.Id == 0)
                return false;

            return Id == entityTmp.Id;
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        public static bool operator ==(Entidade entityA, Entidade entityB)
        {
            if (ReferenceEquals(entityA, null) && ReferenceEquals(entityB, null))
                return true;

            if (ReferenceEquals(entityA, null) || ReferenceEquals(entityB, null))
                return false;

            return entityA.Equals(entityB);
        }

        public static bool operator !=(Entidade entityA, Entidade entityB)
        {
            return !(entityA == entityB);
        }
        #endregion
    }
}
