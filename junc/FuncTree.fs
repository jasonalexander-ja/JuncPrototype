module junc.FuncTree

open junc.Func


type FuncTree =
    | Func of string * IFunc * FuncTree list
    
    member this.Name =
        match this with
        | Func(name, _, _) -> name
        
    member this.Ident =
        match this with
        | Func(_, func, _) -> func.Ident
        
    member this.GetFunc =
        match this with
        | Func(_, func, _) -> func
        
    member this.Call (param: FuncTree) =
        this.GetFunc.Call param.GetFunc
        
    member this.GetChild name =
        match this with
        | Func(_, _, children) ->
            List.tryFind (fun (c: FuncTree) -> c.Name = name) children
        
        
type FuncTrace =
    | Root
    | Sub of string * FuncTree list * FuncTrace
    
    member this.ParentName =
        match this with
        | Root -> "/"
        | Sub(name, _, _) -> name
        
        
type FZipper =
    | FuncZipper of FuncTree * FuncTrace
    
    member this.CurrentName =
        match this with
        |FuncZipper(funcTree, _) -> funcTree.Name
    
    member this.ParentName =
        match this with
        |FuncZipper(_, path) -> path.ParentName
        
        