#include "board.h"

int main()
{
    Board b(7);
    b.print();
    b.setup();
    b.play();
    return 0;
}
