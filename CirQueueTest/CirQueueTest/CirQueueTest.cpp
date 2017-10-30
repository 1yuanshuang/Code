// CirQueueTest.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <string.h>  
#include <stdio.h>  
#include <stdlib.h>

#define MAXSIZE 11
typedef int ElemType;
typedef struct Queue {
	ElemType *base;
	int wp;//写指针  
	int rp;//读指针  
	int queueCnt;
} QUEUE;

typedef enum {
	QueueFull = 0,
	QueueEmpty,
	QueueOK,
	QueueFail
} QueueStatus;

QueueStatus init_queue(QUEUE* queue);
QueueStatus inQueue(ElemType val, QUEUE* queue);
QueueStatus outQueue(QUEUE* queue, ElemType *val);
int readQueue(ElemType *buf, int size, QUEUE *queue);
int writeQueue(const ElemType *buf, int size, QUEUE *queue);


QueueStatus init_queue(QUEUE* queue)
{
	queue->base = (ElemType *)calloc(sizeof(ElemType) * MAXSIZE, 1);
	if (queue->base == NULL)
	{
		printf("failed malloc()");
		return QueueFail;
	}
	queue->wp = queue->rp = 0;
	queue->queueCnt = 0; 
}

int isFull(QUEUE *queue)
{
	return (queue->queueCnt == MAXSIZE - 1) ? 1 : 0;
}

//static int isFull(QUEUE *queue)
//{
//	if (queue->rp == (queue->wp + 1) % queue->maxCount)    //判断循环链表是否满，留一个预留空间不用  
//		return 1;
//	else
//		return 0;
//}

int isEmpty(QUEUE *queue)
{
	return (0 == queue->queueCnt) ? 1 : 0;
}

int get_available(QUEUE *queue)
{
	return MAXSIZE - queue->queueCnt;
}

int get_exist(QUEUE *queue)
{
	return queue->queueCnt;
}

QueueStatus inQueue(ElemType val, QUEUE *queue)
{
	if (1 == isFull(queue))
	{
		return QueueFull;
	}
	else
	{
		memcpy((queue->base + queue->wp), &val, sizeof(ElemType));
		if (++(queue->wp) == MAXSIZE)
		{
			queue->wp = 0;
		}
		//元素个数加1  
		(queue->queueCnt)++;
	}
	return QueueOK;
}

QueueStatus outQueue(QUEUE *queue, ElemType *val)
{
	if (1 == isEmpty(queue))
	{
		return QueueEmpty;
	}
	else 
	{
		int index = queue->rp;
		if (++(queue->rp) == MAXSIZE)
		{
			queue->rp = 0;
		}
		(queue->queueCnt)--;
		memcpy(val, (queue->base + index), sizeof(ElemType));
	}
	return QueueOK;
}

int readQueue(ElemType *buf, int len, QUEUE * queue)
{
	int i;
	ElemType val;
	if (isEmpty(queue))
	{
		return false;
	}
	//读取元素个数大于现有元素个数，读取溢出
	if (len > queue->queueCnt)
	{
		printf("read overflow");
		return false;
	}

	//int count = (queue->wp - queue->rp + MAXSIZE) % MAXSIZE;

	if (queue->rp + len <= MAXSIZE)
	{
		for (i = 0; i < len; i++)
		{
			QueueStatus ret = outQueue(queue, &val);

			if (ret != QueueEmpty)
			{
				memcpy(buf + i, &val, sizeof(ElemType));
			}
			else
			{
				break;
			}
		}	
	}

	else
	{		
		int first=MAXSIZE - 1 - queue->rp;
		int second = len - first;

		for (i = 0; i < first; i++)
		{
			QueueStatus ret = outQueue(queue, &val);
			memcpy(buf + i, &val, sizeof(ElemType));
 		}

		for (i = 0; i < second; i++)
		{	
			QueueStatus ret = outQueue(queue, &val);
			memcpy(buf+first+i, &val, sizeof(ElemType));
		}
	}

	return i;
}

int writeQueue(const ElemType *buf, int len, QUEUE *queue)
{
	int i;

	if (isFull(queue))
	{
		return false;
	}

	int result = MAXSIZE -1-queue->wp;
	if (result >= len)
	{
		for (i = 0; i < len; i++)
		{
			QueueStatus ret = inQueue(buf[i], queue);
		}
	}
	else
	{
		for (i = 0; i <result; i++)
		{
			QueueStatus ret = inQueue(buf[i], queue);
		}

		int first = len - result;

		for (int i = 0; i < first; i++)
		{
			QueueStatus ret = inQueue(buf[i], queue);
		}
	 
	}

	return i;
}

int main(void)
{
	QUEUE queue;
	init_queue(&queue);
	int ret;
	int a[10] = { 0,1,2,3,4,5,6,7,8,9};

	ret = writeQueue(a, 10, &queue);
	//ret = writeQueue(a, 2, &queue);
	printf("writeQueue:\n");
	for (int i = 0; i < 10; i++)
	{
		printf("%d ", a[i]);
	}
	printf("\n");
	printf("The Available space:%d\n", get_available(&queue));

	if (ret <= 0)
	{
		printf("the queue is full/n");
		return -1;
	}

	int buf[20] = { 0 };


	ret = readQueue(buf, 3, &queue);
	printf("readQueue:\n");

	if (ret > 0)
	{
		for (int i = 0; i < 3; i++)
		{
			printf("%d ", buf[i]);
		}
	}
	printf("\n");
	printf("The Available space:%d\n", get_available(&queue));


	ret = readQueue(buf, 5, &queue);
	printf("readQueue:\n");

	if (ret > 0)
	{
		for (int i = 0; i < 5; i++)
		{
			printf("%d ", buf[i]);
		}
	}
	printf("\n");
	printf("The Available space:%d\n", get_available(&queue));

	ret = writeQueue(a, 5, &queue);
	printf("writeQueue:\n");
	for (int i = 0; i < 5; i++)
	{
		printf("%d ", a[i]);
	}
	printf("\n");
	printf("The Available space:%d\n", get_available(&queue));
 
	ret = readQueue(buf, 6, &queue);
	printf("readQueue:\n");

	if (ret > 0)
	{
		for (int i = 0; i <6; i++)
		{
			printf("%d ", buf[i]);
		}
	}
	printf("\n");
	printf("The Available space:%d\n", get_available(&queue));
	//ret = writeQueue(a, 8, &queue);
	//printf("writeQueue:\n");

	//for (int i = 0; i < 8; i++)
	//{
	//	printf("%d ", a[i]);
	//}
 
	printf("The Queue already existed:%d\n", get_exist(&queue));

	return 0;
}

