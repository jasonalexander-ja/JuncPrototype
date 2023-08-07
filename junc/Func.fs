module junc.Func


type IFunc =
    abstract member Call: param: IFunc -> IFunc
    abstract member Ident: Unit -> string
