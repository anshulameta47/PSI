func @_com.Sapient.AudioBook.getCd$$() -> none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\AudioBook.cs" :12 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\AudioBook.cs" :14 :19) // Not a variable of known type: cd
return %0 : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\AudioBook.cs" :14 :12)

^1: // ExitBlock
cbde.unreachable

}
func @_com.Sapient.AudioBook.setCd$string$(none) -> () loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\AudioBook.cs" :17 :8) {
^entry (%_cd : none):
%0 = cbde.alloca none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\AudioBook.cs" :17 :26)
cbde.store %_cd, %0 : memref<none> loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\AudioBook.cs" :17 :26)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\AudioBook.cs" :19 :12) // this (ThisExpression)
%2 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\AudioBook.cs" :19 :12) // this.cd (SimpleMemberAccessExpression)
%3 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\AudioBook.cs" :19 :20) // Not a variable of known type: cd
br ^1

^1: // ExitBlock
return

}
func @_com.Sapient.AudioBook.Play$$() -> () loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\AudioBook.cs" :21 :8) {
^entry :
br ^0

^0: // SimpleBlock
// Entity from another assembly: Console
%0 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\AudioBook.cs" :23 :30) // "Cd is playing" (StringLiteralExpression)
%1 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\AudioBook.cs" :23 :12) // Console.WriteLine("Cd is playing") (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
