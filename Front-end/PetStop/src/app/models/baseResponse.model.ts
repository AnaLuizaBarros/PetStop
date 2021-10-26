export interface BaseResponse<T> {
  data: T; // List de retorno da request, caso successo
  code: number; // status code da request
  message: string; // mensagem retornada pela api
  page: number; // pagina requisitada, se houver
  amount: number; // quantidade de itens por pagina
  total: number; // total de registros no banco
}
