#include <sys/types.h>
#include <unistd.h>
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int main(int argc, char *argv[], char* envp[])
{
	char *p;
	int i;

        if(argc != 2)
		printf("usage: %s <env variable name>\n", argv[0]), exit(0);
	for(p = envp[0], i=0; p; i++, p = envp[i])
		if(!strncmp(p, argv[1],strlen(argv[1])))
			printf("%s\n", p);
	exit(0);
}
