func @_com.Sapient.NormalBook.getTitle$$() -> none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :20 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :22 :19) // this (ThisExpression)
%1 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :22 :19) // this.title (SimpleMemberAccessExpression)
return %1 : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :22 :12)

^1: // ExitBlock
cbde.unreachable

}
func @_com.Sapient.NormalBook.getAuthor$$() -> none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :24 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :26 :19) // this (ThisExpression)
%1 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :26 :19) // this.author (SimpleMemberAccessExpression)
return %1 : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :26 :12)

^1: // ExitBlock
cbde.unreachable

}
func @_com.Sapient.NormalBook.getPrice$$() -> none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :28 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :30 :19) // this (ThisExpression)
%1 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :30 :19) // this.price (SimpleMemberAccessExpression)
return %1 : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :30 :12)

^1: // ExitBlock
cbde.unreachable

}
func @_com.Sapient.NormalBook.setPrice$float$(none) -> () loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :32 :8) {
^entry (%_price : none):
%0 = cbde.alloca none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :32 :29)
cbde.store %_price, %0 : memref<none> loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :32 :29)
br ^0

^0: // BinaryBranchBlock
%1 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :34 :15) // Not a variable of known type: price
%2 = constant 0 : i32 loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :34 :21)
%3 = cbde.unknown : i1  loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :34 :15) // comparison of unknown type: price<0
cond_br %3, ^1, ^2 loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :34 :15)

^1: // JumpBlock
%4 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :35 :32) // "Price cannot be negative" (StringLiteralExpression)
%5 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :35 :18) // new Exception("Price cannot be negative") (ObjectCreationExpression)
cbde.throw %5 :  none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :35 :12)

^2: // SimpleBlock
%6 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :37 :12) // this (ThisExpression)
%7 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :37 :12) // this.price (SimpleMemberAccessExpression)
%8 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :37 :23) // Not a variable of known type: price
br ^3

^3: // ExitBlock
return

}
func @_com.Sapient.NormalBook.setId$int$(i32) -> () loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :39 :8) {
^entry (%_id : i32):
%0 = cbde.alloca i32 loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :39 :26)
cbde.store %_id, %0 : memref<i32> loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :39 :26)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :41 :12) // this (ThisExpression)
%2 = cbde.unknown : i32 loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :41 :12) // this.id (SimpleMemberAccessExpression)
%3 = cbde.load %0 : memref<i32> loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :41 :20)
br ^1

^1: // ExitBlock
return

}
func @_com.Sapient.NormalBook.ToString$$() -> none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :43 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :26) // "Title:" (StringLiteralExpression)
%1 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :35) // Not a variable of known type: title
%2 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :26) // Binary expression on unsupported types "Title:"+title
%3 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :42) // " Author:" (StringLiteralExpression)
%4 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :26) // Binary expression on unsupported types "Title:"+title +" Author:"
%5 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :53) // Not a variable of known type: author
%6 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :26) // Binary expression on unsupported types "Title:"+title +" Author:"+author
%7 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :61) // " price:" (StringLiteralExpression)
%8 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :26) // Binary expression on unsupported types "Title:"+title +" Author:"+author+ " price:"
%9 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :71) // Not a variable of known type: price
%10 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :26) // Binary expression on unsupported types "Title:"+title +" Author:"+author+ " price:"+price
%11 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :77) // " Id:" (StringLiteralExpression)
%12 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :26) // Binary expression on unsupported types "Title:"+title +" Author:"+author+ " price:"+price+" Id:"
%13 = cbde.unknown : i32 loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :84) // Not a variable of known type: id
%14 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :45 :26) // Binary expression on unsupported types "Title:"+title +" Author:"+author+ " price:"+price+" Id:"+id
%16 = cbde.unknown : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :46 :19) // Not a variable of known type: output
return %16 : none loc("C:\\Users\\ansameta\\Desktop\\Ps_bootcamp\\bootcamp-training\\week1\\day4\\Proj2\\NormalBook.cs" :46 :12)

^1: // ExitBlock
cbde.unreachable

}
