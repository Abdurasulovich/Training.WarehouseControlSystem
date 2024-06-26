﻿namespace Training.WarehouseControlSystem.Domain.Common.Exceptions;

public class FuncResult<T>
{
    public T Data { get; init; }

    public Exception? Exception { get; }

    public bool IsSuccess => Exception is null;

    public FuncResult(T data) => Data = data;
    
    public FuncResult(Exception exeption) => Exception = exeption;
}
