﻿using System;

namespace Tlabs.Proc.Common {

  ///<summary>Descriptor of a <typeparamref name="TProc"/> procedure implementing <see cref="IAutoProcedure{TMsg, TRes}"/>.</summary>
  public abstract class AutoProcedurDescriptor<TProc, TMsg, TRes> : IAutoProcedureDescriptor<TMsg, TRes>
    where TProc : IAutoProcedure<TMsg, TRes> where TMsg : class where TRes : notnull {
    ///<summary>Ctor from <paramref name="prcsType"/>.</summary>
    protected AutoProcedurDescriptor(AutoProcessType<TMsg, TRes> prcsType) {
      this.ProcessType= prcsType;
      this.Description= string.Empty;
      this.Name= GetType().FullName ?? GetType().Name;
    }
    ///<inheritdoc/>
    public IAutoProcessType ProcessType { get; }
    ///<inheritdoc/>
    public Type ProcedureType => typeof(TProc);
    ///<inheritdoc/>
    public string Name { get; protected set; }
    ///<inheritdoc/>
    public string Description { get; protected set; }
  }

  ///<summary>Interface of an automation procedure matching the specific <see cref="AutoProcessType{TMsg, TRes}"/>.</summary>
  public interface IAutoProcedureDescriptor<TMsg, TRes> : IAutoProcedureDescriptor, IDefaultAutoProcedureType, IResultAutoProcedureType { }

  ///<summary>Interface of a LOP processor.</summary>
  public interface IAutoProcedureDescriptor : IAutomationDescriptor, IAutoProcedureType {
    ///<summary>Process type.</summary>
    IAutoProcessType ProcessType { get; }
    ///<summary>Automation procedure type.</summary>
    Type ProcedureType { get; }
  }

  ///<summary>Base interface of an automation procedure config classes.</summary>
  public interface IAutoProcedureType { }

  ///<summary>Interface to be used to register default procedure(s) with DI.</summary>
  public interface IDefaultAutoProcedureType : IAutoProcedureType { }

  ///<summary>Interface to be used to register procedure(s) providng the result with DI.</summary>
  public interface IResultAutoProcedureType : IAutoProcedureType { }

}