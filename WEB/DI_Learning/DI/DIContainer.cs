namespace DI_Learning.DI
{
    public class DIContainer
    {
        public static T GetService<T>()
        {
            var type = typeof(T);

            var constructor = type.GetConstructors().First();
            var parametrs = constructor.GetParameters();

            var parametrObject = Activator.CreateInstance(parametrs[0].ParameterType);

            var @object = (T)Activator.CreateInstance(type, parametrObject);
            return @object;
        }
    }
}
