#include <sys/types.h>
#include <unistd.h>
#include <stdlib.h>
#include <stdio.h>

int main(int argc, char *argv[], char* envp[])
{
        printf("PID = %d, UID = %d, GID = %d\n", getpid(), getuid(), getgid());
	exit(0);
}
