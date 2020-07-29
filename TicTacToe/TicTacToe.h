#pragma once
#include <string>
#include <iostream>
using namespace std;

enum class Options { NONE = 0, O = 1, X = 2 };
enum class Outcome { NONE = 0, P1WINS = 1, P2WINS = 2, DRAW = 3 };

class Board
{
	class Player
	{
	private:
		bool isHuman;
		string name;
		Options symbol;
	public:
		Player(string name, Options symbol, bool isHuman = true) :isHuman(isHuman), symbol(symbol), name(name) {}
		Options getSymbol() const { return symbol; }
		void presentMakeMove() const;
		void present() const;
		bool isHuman() const { return isHuman; }
	};
private:
	enum { SIZE = 9 };
	Options* moves;
	Player* p1;
	Player* p2;
	Player* turn;
	int xMax, yMax;
public:
	Board(int size = SIZE);
	Board(const Board&);
	~Board();
	void start();
	void play();
	bool makeMove(int);
	int makeMoveAuto();
	void showBoard() const;
	void setPlayer1(const Options, string, bool);
	void setPlayer2(const Options, string, bool);
	Player* getPlayer1() const { return p1; }
	Player* getPlayer2() const { return p2; }
	Player* getTurn() const { return turn; }
	void setTurn(Player* p) { turn = p; }
	int getxMax() const { return xMax; }
	int getyMax() const { return yMax; }
	int getSize() const { return xMax * yMax; }
	Options getMove(int line, int column) const { return moves[column + line * 3]; }
	Options getMove(int pos) const { return moves[pos]; }
	Player* getPlayerByOption(Options) const;
	void clear();
	Board& operator=(const Board&);
};