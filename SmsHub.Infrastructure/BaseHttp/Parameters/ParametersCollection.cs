using SmsHub.Infrastructure.BaseHttp.Enums;
using System.Collections;

namespace SmsHub.Infrastructure.BaseHttp.Parameters
{
    public abstract class ParametersCollection<T> : IReadOnlyCollection<T> where T : BaseParameter
    {
        protected readonly List<T> Parameters = new List<T>();

        static readonly Func<T, string?, bool> SearchPredicate = (p, name)
            => p.Name != null && p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase);

        public bool Exists(T parameter) => Parameters.Any(p => SearchPredicate(p, parameter.Name) && p.Type == parameter.Type);

        public T? TryFind(string parameterName) => Parameters.FirstOrDefault(x => SearchPredicate(x, parameterName));

        public IEnumerable<TParameter> GetParameters<TParameter>() where TParameter : class, T => Parameters.OfType<TParameter>();

        public IEnumerator<T> GetEnumerator() => Parameters.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => Parameters.Count;
    }

    public abstract class ParametersCollection : ParametersCollection<BaseParameter>
    {
        public IEnumerable<BaseParameter> GetParameters(ParameterType parameterType) => Parameters.Where(x => x.Type == parameterType);
    }
}
