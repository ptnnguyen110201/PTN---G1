using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class DIContainer    
{
    private readonly Dictionary<Type, Func<object>> Bindings = new();
    private readonly Dictionary<Type, object> CachedInstances = new();

    public void Bind<TInterface, TImplementation>() where TImplementation : TInterface
    {
        this.Bindings[typeof(TInterface)] = () => this.CreateInstance(typeof(TImplementation));
    }

    public void BindInstance<TInterface>(TInterface instance)
    {
        this.CachedInstances[typeof(TInterface)] = instance;
    }
    public void Bind<TInterface>(Func<object> factory)
    {
        this.Bindings[typeof(TInterface)] = factory;
    }

    public TInterface Resolve<TInterface>()
    {
        return (TInterface)Resolve(typeof(TInterface));
    }

    public object Resolve(Type type)
    {
        if (this.CachedInstances.TryGetValue(type, out object cached))
            return cached;

        if (this.Bindings.TryGetValue(type, out Func<object> creator))
        {
            object instance = creator();
            this.CachedInstances[type] = instance;
            return instance;
        }

        if (!type.IsAbstract)
        {
            object instance = CreateInstance(type);
            this.CachedInstances[type] = instance;
            return instance;
        }

        throw new Exception($"No binding found for type {type}");
    }

    private object CreateInstance(Type type)
    {
        ConstructorInfo ctor = type.GetConstructors()
            .OrderByDescending(c => c.GetParameters().Length)
            .FirstOrDefault();

        if (ctor == null)
            throw new Exception($"No public constructor found for {type.Name}");

        ParameterInfo[] parameters = ctor.GetParameters();
        object[] args = parameters.Select(p => Resolve(p.ParameterType)).ToArray();

        object instance = Activator.CreateInstance(type, args);
        this.InjectInto(instance);
        return instance;
    }

    public void InjectInto(object target)
    {
        FieldInfo[] fields = target.GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .Where(f => f.GetCustomAttribute<InjectAttribute>() != null)
            .ToArray();

        foreach (FieldInfo field in fields)
        {
            object dependency = Resolve(field.FieldType);
            field.SetValue(target, dependency);
        }
    }
}
