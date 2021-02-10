#include <map>
#include <string>
#include <vector>
using namespace std;
#ifndef BOARD_HPP
#define BOARD_HPP
enum class Choice
{
    kNONE = 0,
    kRED = 1,
    kBLUE = 2
};

class Board
{
private:
    map<string, Choice> moves;
    map<string, vector<string>> connections;
    int size;
    void printMove(int, int);
    void printLineSeparator(int);
    void printColumnSeparator();
    void printIdent(int);
    Choice turn;
    bool finish();
    Choice computer;
    void makeComputerMove();
    void printMoves();
    void buildConnections();
    void printConnections();
    void blueWon(bool&);
    void redWon(bool&);
    bool findWinPath(string, Choice, vector<string>&, bool&);
    bool isFinalPosition(string, Choice);

public:
    Board(int size = 11) : size(size)
    {
        buildConnections();
    }
    ~Board();
    void setup();
    void play();
    void print();
    void makeMove(string);
    void insertMove(string, Choice);
    int getSize()
    {
        return size;
    }
    static string getTextPos(int, int);
    bool posFree(string pos);
    Choice whoWon();
};
#endif
