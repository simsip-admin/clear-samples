using Refit;
using Simsip.Demo;
using System.Reflection;


namespace Models.Refit
{
    public class CustomUrlParameterFormatter : DefaultUrlParameterFormatter
    {
        public override string Format(object parameterValue, ParameterInfo parameterInfo)
        {
            if (parameterValue == null)
                return null;

            if (parameterInfo.Name == "token")
            {
                return App.Instance.Token;
            }

            return base.Format(parameterValue, parameterInfo);
        }
    }
}
