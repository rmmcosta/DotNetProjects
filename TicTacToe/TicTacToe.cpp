#include "TicTacToe.h"
#include <vector>
#include <algorithm>

ostream& operator<<(ostream&, const Options&);
ostream& operator<<(ostream&, const Outcome&);
void printLine(int);
int selectMode();
void humanVsHuman(Board&);
void computerVsHuman(Board&);
void computerVsHuman_Hard(Board&);
void computerVsHuman_Impossible(Board&);
void computerVsComputer(Board&);
Options chooseSymbol();
void endGame(Outcome&, Board&);
Outcome evaluate(Board&);
Outcome evaluateDiagonals(Board&);
Outcome evaluateDiagonal00(Board&);
Outcome evaluateDiagonal20(Board&);
Outcome evaluateLines(Board&);
Outcome evaluateColumns(Board&);
Outcome evaluateDraw(Board&);
int previewMove(Board&, int, Outcome);
int previewMove_Hard(Board, int, Outcome, bool, int);
int minimax(Board&, int, bool);
int findBestMove(Board&);

Board::Board(const Board& b)
{
	//cout << "copy constructor" << endl;
	this->moves = new Options[b.getSize()];
	for (int i = 0; i < b.getSize(); i++)
	{
		//cout << "copy move: " << b.getMove(i) << endl;
		setMove(i, b.getMove(i));
	}
	this->p1 = new Player(b.p1->getName(), b.p1->getSymbol(), b.p1->getLevel(), b.p1->getIsHuman());
	this->p2 = new Player(b.p2->getName(), b.p2->getSymbol(), b.p2->getLevel(), b.p2->getIsHuman());
	this->turn = b.turn == b.p1 ? p1 : p2;
	this->xMax = b.xMax;
	this->yMax = b.yMax;
	//cout << "end copy constructor" << endl;
}

Board& Board::operator=(const Board& b)
{
	//cout << "assignment operator" << endl;
	this->moves = new Options[b.getSize()];
	for (int i = 0; i < b.getSize(); i++)
	{
		//cout << "copy move: " << b.getMove(i) << endl;
		setMove(i, b.getMove(i));
	}
	this->p1 = new Player(b.p1->getName(), b.p1->getSymbol(), b.p1->getLevel(), b.p1->getIsHuman());
	this->p2 = new Player(b.p2->getName(), b.p2->getSymbol(), b.p2->getLevel(), b.p2->getIsHuman());
	this->turn = b.turn == b.p1 ? p1 : p2;
	this->xMax = b.xMax;
	this->yMax = b.yMax;
	return *this;
}

ostream& operator<<(ostream& out, const Options& opt)
{
	switch (opt)
	{
	case Options::O:
		out << "O";
		break;
	case Options::X:
		out << "X";
		break;
	default:
		out << " ";
		break;
	}
	return out;
}

ostream& operator<<(ostream& out, const Outcome& outcome)
{
	switch (outcome)
	{
	case Outcome::DRAW:
		out << "draw";
		break;
	case Outcome::P1WINS:
		out << "p1 wins";
		break;
	case Outcome::P2WINS:
		out << "p2 wins";
		break;
	default:
		out << "none";
		break;
	}
	return out;
}

void Board::clear()
{
	for (int i = 0; i < getxMax() * getyMax(); i++)
	{
		moves[i] = Options::NONE;
	}
}

Board::Board(int size)
{
	p1 = p2 = turn = nullptr;
	moves = new Options[size];
	xMax = static_cast<int>(sqrt(size));
	yMax = xMax;
	clear();
}

Board::~Board()
{
	delete[] moves;
	delete p1;
	delete p2;
}

void Board::showBoard() const
{
	cout << endl;
	for (int i = 0; i < xMax; i++)
	{
		for (int j = 0; j < yMax; j++)
		{
			cout << " " << getMove(i, j) << " ";
			if (j < yMax - 1)
				cout << "|";
		}
		if (i < xMax - 1)
			printLine(xMax * 3);
	}
	cout << endl
		<< endl;
}

void printLine(int n)
{
	cout << endl;
	for (int i = 0; i <= n; i++)
	{
		cout << '-';
	}
	cout << '-' << endl;
}

void Board::start()
{
	int mode = selectMode();
	switch (mode)
	{
	case 1:
		humanVsHuman(*this);
		break;
	case 2:
		computerVsHuman(*this);
		break;
	case 3:
		computerVsHuman_Hard(*this);
		break;
	case 4:
		computerVsHuman_Impossible(*this);
		break;
	case 5:
		computerVsComputer(*this);
		break;
	default:
		humanVsHuman(*this);
		break;
	}
}

void Board::setPlayer1(const Options symbol, string name, Level level, bool isHuman)
{
	p1 = new Player(name, symbol, level, isHuman);
}

void Board::setPlayer2(const Options symbol, string name, Level level, bool isHuman)
{
	p2 = new Player(name, symbol, level, isHuman);
}

int selectMode()
{
	int mode = -1;
	while (mode < 1 || mode > 6)
	{
		cout << "Please select the mode:" << endl;
		cout << "1 - Human vs Human" << endl;
		cout << "2 - Computer vs Human (easy)" << endl;
		cout << "3 - Computer vs Human (hard)" << endl;
		cout << "4 - Computer vs Human (impossible)" << endl;
		cout << "5 - Computer vs Computer" << endl;
		cout << "6 - Quit" << endl;
		cout << "->";
		cin >> mode;
	}
	if (mode == 6)
		exit(0);
	return mode;
}

void humanVsHuman(Board& b)
{
	cout << "Player 1 name:";
	string name;
	cin >> name;
	Options symbol = chooseSymbol();
	b.setPlayer1(symbol, name, Level::EASY, true);
	cout << endl
		<< "Player 2 name:";
	cin >> name;
	symbol = symbol == Options::O ? Options::X : Options::O;
	b.setPlayer2(symbol, name, Level::EASY, true);
	b.setTurn(b.getPlayer1());
}
void computerVsHuman(Board& b)
{
	cout << "Your name:";
	string name;
	cin >> name;
	Options symbol = chooseSymbol();
	b.setPlayer1(symbol, name, Level::EASY, true);
	name = "The Computer";
	symbol = symbol == Options::O ? Options::X : Options::O;
	b.setPlayer2(symbol, name, Level::EASY, false);
	b.setTurn(b.getPlayer1());
}
void computerVsHuman_Hard(Board& b)
{
	cout << "Your name:";
	string name;
	cin >> name;
	Options symbol = chooseSymbol();
	b.setPlayer1(symbol, name, Level::EASY, true);
	name = "The Computer";
	symbol = symbol == Options::O ? Options::X : Options::O;
	b.setPlayer2(symbol, name, Level::HARD, false);
	b.setTurn(b.getPlayer1());
}
void computerVsHuman_Impossible(Board& b)
{
	cout << "Your name:";
	string name;
	cin >> name;
	Options symbol = chooseSymbol();
	b.setPlayer1(symbol, name, Level::EASY, true);
	name = "The Computer";
	symbol = symbol == Options::O ? Options::X : Options::O;
	b.setPlayer2(symbol, name, Level::IMPOSSIBLE, false);
	b.setTurn(b.getPlayer1());
}
void computerVsComputer(Board& b)
{
	string name = "The Computer 1";
	b.setPlayer1(Options::O, name, Level::IMPOSSIBLE, false);
	name = "The Computer 2";
	b.setPlayer2(Options::X, name, Level::IMPOSSIBLE, false);
	b.setTurn(b.getPlayer1());
}

Options chooseSymbol()
{
	int opt = -1;
	while (opt < 1 || opt > 2)
	{
		cout << "Please choose your symbol:" << endl;
		cout << "1 - O" << endl;
		cout << "2 - X" << endl;
		cin >> opt;
	}
	return static_cast<Options>(opt);
}

void Board::play()
{
	int move = -1;
	Outcome outcome = Outcome::NONE;
	while (outcome == Outcome::NONE)
	{
		bool r = false;
		if (turn->getIsHuman())
		{
			while (move < 0 || move > 8)
			{
				turn->presentMakeMove();
				cin >> move;
			}
			r = makeMove(move);
		}
		else
		{
			switch (turn->getLevel())
			{
			case Level::EASY:
				move = makeMoveAuto();
				break;
			case Level::HARD:
				move = makeMoveAuto_Hard();
				break;
			case Level::IMPOSSIBLE:
				move = makeMoveAuto_Impossible();
				break;
			default:
				break;
			}
			r = makeMove(move);
		}
		if (r)
			cout << "valid move." << endl;
		else
			cout << "invalid move! Please play again." << endl;
		move = -1;
		showBoard();
		outcome = evaluate(*this);
	}
	endGame(outcome, *this);
	clear();
	start();
	play();
}

void Board::Player::presentMakeMove() const
{
	cout << symbol << " - " << name << " make your move: ";
}

void Board::Player::present() const
{
	cout << name << "(" << symbol << ")";
}

bool Board::makeMove(int move)
{
	if (moves[move] != Options::NONE)
		return false;
	moves[move] = turn->getSymbol();
	previousTurn = turn;
	turn = turn == p1 ? p2 : p1;
	return true;
}

bool Board::makeMove(int line, int column)
{
	int move = line * 3 + column;
	return makeMove(move);
}

bool Board::undoMove(int line, int column)
{
	setMove(line, column, Options::NONE);
	turn = turn == p1 ? p2 : p1;
	return true;
}

int Board::makeMoveAuto()
{
	vector<int> freeMoves;
	Outcome desired = turn == p1 ? Outcome::P1WINS : Outcome::P2WINS;
	int move = -1;
	int max = -100;
	for (int i = 0; i < getSize(); i++)
	{
		if (getMove(i) == Options::NONE)
			freeMoves.push_back(i);
	}
	//cout << freeMoves.size() << " positions are still free." << endl;
	while (!freeMoves.empty())
	{
		//cout << "next move :" << freeMoves[freeMoves.size() - 1];
		int nextMove = freeMoves[freeMoves.size() - 1];
		//cout << "free move: " << nextMove << endl;
		Board* tempBoard = new Board(*this);
		int tempMax = previewMove(*tempBoard, nextMove, desired);
		//cout << "temp max: " << tempMax << endl;
		//cout << "tempMax > max: " << (tempMax > max) << "nextMove: " << nextMove << endl;
		if (tempMax > max)
		{
			max = tempMax;
			move = nextMove;
		}
		freeMoves.pop_back();
		//cout << "next free Move" << endl;
		delete tempBoard;
		//cout << "deleted temp board" << endl;
	}
	return move;
}

int previewMove(Board& newBoard, int move, Outcome desired)
{
	/*cout << "move: " << move << " desired: " << desired << endl;
	newBoard.showBoard();*/
	bool r = newBoard.makeMove(move);
	if (!r)
		return -10;
	Outcome currOutcome = evaluate(newBoard);
	//cout << "curroutcome " << currOutcome << endl;
	if (currOutcome == Outcome::NONE)
	{
		for (int i = 0; i < newBoard.getSize(); i++)
		{
			if (newBoard.getMove(i) == Options::NONE)
				return previewMove(newBoard, i, desired);
		}
	}
	if (currOutcome == desired)
		return 10;
	if (currOutcome == Outcome::DRAW)
		return 0;
	return -10;
}

int Board::makeMoveAuto_Hard()
{
	int bestMove = -1;
	int bestValue = -100;
	for (int i = 0; i < getSize(); i++)
	{
		if (getMove(i) == Options::NONE)
		{
			int currValue = previewMove_Hard(*this, i, turn == p1 ? Outcome::P1WINS : Outcome::P2WINS, true, 0);
			if (currValue > bestValue)
			{
				bestValue = currValue;
				bestMove = i;
			}
		}
	}
	return bestMove;
}

int previewMove_Hard(Board newBoard, int move, Outcome desired, bool isMaximize, int depth)
{
	newBoard.makeMove(move);
	Outcome currOutcome = evaluate(newBoard);
	if (currOutcome == desired)
		return 10 - depth;
	if (currOutcome == Outcome::DRAW)
		return 0;
	if (currOutcome != Outcome::NONE)
		return -10 + depth;
	depth++;
	if (isMaximize)
	{
		int bestValue = -100;
		for (int i = 0; i < newBoard.getSize(); i++)
		{
			if (newBoard.getMove(i) == Options::NONE)
			{
				int currValue = previewMove_Hard(newBoard, i, desired, false, depth);
				if (currValue > bestValue)
				{
					bestValue = currValue;
				}
			}
		}
		return bestValue;
	}
	else
	{
		int bestValue = 100;
		for (int i = 0; i < newBoard.getSize(); i++)
		{
			if (newBoard.getMove(i) == Options::NONE)
			{
				int currValue = previewMove_Hard(newBoard, i, desired, false, depth);
				if (currValue < bestValue)
				{
					bestValue = currValue;
				}
			}
		}
		return bestValue;
	}
}

void endGame(Outcome& outcome, Board& b)
{
	switch (outcome)
	{
	case Outcome::DRAW:
		cout << "It's a draw!" << endl;
		break;
	case Outcome::P1WINS:
		cout << "Player 1 ";
		b.getPlayer1()->present();
		cout << " Wins!" << endl;
		break;
	case Outcome::P2WINS:
		cout << "Player 2 ";
		b.getPlayer2()->present();
		cout << " Wins!" << endl;
		break;
	default:
		cout << "Something went wrong" << endl;
		break;
	}
}

Outcome evaluate(Board& board)
{
	Outcome outcome = evaluateDiagonals(board);
	if (outcome == Outcome::NONE)
		outcome = evaluateColumns(board);
	if (outcome == Outcome::NONE)
		outcome = evaluateLines(board);
	if (outcome == Outcome::NONE)
		outcome = evaluateDraw(board);
	return outcome;
}

Outcome evaluateDiagonals(Board& b)
{
	Outcome s = evaluateDiagonal00(b);
	if (s != Outcome::NONE)
		return s;
	s = evaluateDiagonal20(b);
	return s;
}

Outcome evaluateDiagonal00(Board& b)
{
	//cout << "diagonal 00" << endl;
	//0,0-1,1-2,2
	int i = 0, j = 0;
	Options s = Options::NONE;
	while (i < b.getxMax() && j < b.getyMax())
	{
		if (b.getMove(i, j) == Options::NONE)
			return Outcome::NONE;
		if (s == Options::NONE)
		{
			s = b.getMove(i, j);
			i++;
			j++;
			continue;
		}
		if (s != b.getMove(i, j))
		{
			return Outcome::NONE;
		}
		i++;
		j++;
	}
	if (b.getPlayerByOption(s) == b.getPlayer1())
		return Outcome::P1WINS;
	if (b.getPlayerByOption(s) == b.getPlayer2())
		return Outcome::P2WINS;
	return Outcome::NONE;
}

Outcome evaluateDiagonal20(Board& b)
{
	//2,0-1,1-0,2
	//cout << "diagonal 20" << endl;
	int i = 2, j = 0;
	Options s = Options::NONE;
	while (i >= 0 && j < b.getyMax())
	{
		if (b.getMove(i, j) == Options::NONE)
			return Outcome::NONE;
		if (s == Options::NONE)
		{
			s = b.getMove(i, j);
			i--;
			j++;
			continue;
		}
		if (s != b.getMove(i, j))
		{
			return Outcome::NONE;
		}
		i--;
		j++;
	}
	if (b.getPlayerByOption(s) == b.getPlayer1())
		return Outcome::P1WINS;
	if (b.getPlayerByOption(s) == b.getPlayer2())
		return Outcome::P2WINS;
	return Outcome::NONE;
}

Outcome evaluateLines(Board& b)
{
	//cout << "Lines" << endl;
	Options s = Options::NONE;
	//i is the line and j the column
	for (int i = 0; i < b.getxMax(); i++)
	{
		for (int j = 0; j < b.getyMax(); j++)
		{
			if (b.getMove(i, j) == Options::NONE)
			{
				s = Options::NONE;
				break;
			}
			if (s == Options::NONE)
			{
				s = b.getMove(i, j);
				continue;
			}
			if (s != b.getMove(i, j))
			{
				s = Options::NONE;
				break;
			}
		}
		if (s != Options::NONE)
		{
			if (b.getPlayerByOption(s) == b.getPlayer1())
				return Outcome::P1WINS;
			if (b.getPlayerByOption(s) == b.getPlayer2())
				return Outcome::P2WINS;
		}
	}
	if (s == Options::NONE)
		return Outcome::NONE;
	if (b.getPlayerByOption(s) == b.getPlayer1())
		return Outcome::P1WINS;
	if (b.getPlayerByOption(s) == b.getPlayer2())
		return Outcome::P2WINS;
	return Outcome::NONE;
}

Outcome evaluateColumns(Board& b)
{
	//cout << "columns" << endl;
	Options s = Options::NONE;
	//i is the column and j the line
	for (int i = 0; i < b.getxMax(); i++)
	{
		for (int j = 0; j < b.getyMax(); j++)
		{
			Options currMove = b.getMove(j, i);
			//cout << "getMove " << i << ", " << j << " -> " << currMove << endl;
			if (currMove == Options::NONE)
			{
				s = Options::NONE;
				break;
			}
			if (s == Options::NONE)
			{
				s = currMove;
				continue;
			}
			if (s != currMove)
			{
				s = Options::NONE;
				break;
			}
		}
		if (s != Options::NONE)
		{
			if (b.getPlayerByOption(s) == b.getPlayer1())
				return Outcome::P1WINS;
			if (b.getPlayerByOption(s) == b.getPlayer2())
				return Outcome::P2WINS;
		}
	}
	if (s == Options::NONE)
		return Outcome::NONE;
	if (b.getPlayerByOption(s) == b.getPlayer1())
		return Outcome::P1WINS;
	if (b.getPlayerByOption(s) == b.getPlayer2())
		return Outcome::P2WINS;
	return Outcome::NONE;
}

Outcome evaluateDraw(Board& b)
{
	for (int i = 0; i < b.getxMax(); i++)
	{
		for (int j = 0; j < b.getyMax(); j++)
		{
			if (b.getMove(i, j) == Options::NONE)
				return Outcome::NONE;
		}
	}
	return Outcome::DRAW;
}

Board::Player* Board::getPlayerByOption(Options option) const
{
	if (p1->getSymbol() == option)
		return p1;
	else
		return p2;
}

int minimax(Board& board, int depth, bool isMax, Outcome desire)
{
	Outcome currOutcome = evaluate(board);
	if (currOutcome == desire)
		return 10 - depth;
	if (currOutcome == Outcome::DRAW)
		return 0;
	if (currOutcome != Outcome::NONE)
		return -10 + depth;

	// If this maximizer's move 
	if (isMax)
	{
		int best = -1000;

		// Traverse all cells 
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				// Check if cell is empty 
				if (board.getMove(i, j) == Options::NONE)
				{
					// Make the move 
					Board tempBoard = Board(board);
					tempBoard.makeMove(i, j);

					// Call minimax recursively and choose 
					// the maximum value 
					best = max(best,
						minimax(tempBoard, depth + 1, !isMax, desire));

				}
			}
		}
		return best;
	}

	// If this minimizer's move 
	else
	{
		int best = 1000;

		// Traverse all cells 
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				// Check if cell is empty 
				if (board.getMove(i, j) == Options::NONE)
				{
					// Make the move 
					Board tempBoard = Board(board);
					tempBoard.makeMove(i, j);

					// Call minimax recursively and choose 
					// the minimum value 
					best = min(best,
						minimax(tempBoard, depth + 1, !isMax, desire));
				}
			}
		}
		return best;
	}
}

// This will return the best possible move for the player 
int Board::makeMoveAuto_Impossible()
{
	int bestVal = -1000;
	int bestMove = -1;
	Outcome desire = getDesire();

	// Traverse all cells, evaluate minimax function for 
	// all empty cells. And return the cell with optimal 
	// value. 
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			// Check if cell is empty 
			if (getMove(i, j) == Options::NONE)
			{
				// Make the move 
				Board tempBoard = Board(*this);
				tempBoard.makeMove(i, j);

				// compute evaluation function for this 
				// move. 
				int moveVal = minimax(tempBoard, 0, false, desire);

				// If the value of the current move is 
				// more than the best value, then update 
				// best/ 
				if (moveVal > bestVal)
				{
					bestMove = i * 3 + j;
					bestVal = moveVal;
				}
			}
		}
	}

	cout << "The value of the best Move is : " << bestVal << endl << endl;

	return bestMove;
}