#pragma once
#include <string>
#include <iostream>
using namespace std;
enum class Options
{
	NONE = 0,
	O = 1,
	X = 2
};
enum class Outcome
{
	NONE = 0,
	P1WINS = 1,
	P2WINS = 2,
	DRAW = 3
};
enum class Level
{
	EASY = 1,
	HARD = 2,
	IMPOSSIBLE = 3
};
class Board
{
	class Player
	{
	private:
		bool isHuman;
		string name;
		Options symbol;
		Level level;
	public:
		Player(string name, Options symbol, Level level = Level::EASY, bool isHuman = true) : isHuman(isHuman), level(level), symbol(symbol), name(name) {}
		Options getSymbol() const { return symbol; }
		void presentMakeMove() const;
		void present() const;
		bool getIsHuman() const { return isHuman; }
		string getName() const { return name; }
		Level getLevel() const { return level; }
	};
private:
	enum
	{
		SIZE = 9
	};
	Options* moves;
	Player* p1;
	Player* p2;
	Player* turn;
	Player* previousTurn;
	int xMax, yMax;
public:
	Board(int size = SIZE);
	Board(const Board&);
	~Board();
	void start();
	void play();
	bool makeMove(int);
	bool makeMove(int, int);
	bool undoMove(int, int);
	int makeMoveAuto();
	int makeMoveAuto_Hard();
	int makeMoveAuto_Impossible();
	void showBoard() const;
	void setPlayer1(const Options, string, Level, bool);
	void setPlayer2(const Options, string, Level, bool);
	Player* getPlayer1() const { return p1; }
	Player* getPlayer2() const { return p2; }
	Player* getTurn() const { return turn; }
	void setTurn(Player* p) { turn = p; }
	int getxMax() const { return xMax; }
	int getyMax() const { return yMax; }
	int getSize() const { return xMax * yMax; }
	Options getMove(int line, int column) const { return moves[column + line * 3]; }
	Options getMove(int pos) const { return moves[pos]; }
	void setMove(int pos, Options value) { moves[pos] = value; }
	void setMove(int line, int column, Options value) { moves[line * 3 + column] = value; }
	Player* getPlayerByOption(Options) const;
	Outcome getDesire() const { return turn == p1 ? Outcome::P1WINS : Outcome::P2WINS; }
	void clear();
	Board& operator=(const Board&);
};