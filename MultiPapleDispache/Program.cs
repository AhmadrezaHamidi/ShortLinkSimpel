// See https://aka.ms/new-console-template for more information

using MultiPapleDispache;

Console.WriteLine("Hello, World!");


var circleDraw = new Circle();

var SquareDeaw = new Square();


var whiteBoard = new WhiteBoard();
whiteBoard.Draw(circleDraw);
whiteBoard.Draw(SquareDeaw);

whiteBoard.Draw(SquareDeaw as dynamic);
 