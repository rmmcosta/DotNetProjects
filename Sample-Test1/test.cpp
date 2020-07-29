#include "pch.h"
#include "../MyQueue/MyQueue.h"

TEST(TestCaseName, TestName) {
  EXPECT_EQ(1, 1);
  EXPECT_TRUE(true);
}

TEST(MyQueueTest, isEmpty) {
	MyQueue<int> mq1 = MyQueue<int>();
	EXPECT_TRUE(mq1.isEmpty());
}