public interface IDeclaration<
    TEvent, 
    TSource, 
    TDestionation> 
where TEvent : Event<TEvent>
where TSource: Projection<TSource>, new()
where TDestionation: Projection<TDestionation>, new()
{
  readonly string SubjectIdFieldName;
}
