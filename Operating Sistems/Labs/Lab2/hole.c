#include <unistd.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int main(int argc, char *argv[], char* envp[])
{
        int n, fd;
	char buf1[] = "this is string one\n";
	char buf2[] = "this is string two\n";

	if((fd = creat("file_with_holes", S_IRUSR | S_IWUSR)) < 0)
		perror("creat"), exit(1);

	n = strlen(buf1);
	if(write(fd, buf1, n) != n)
			perror("write"), exit(1);
	
	if(lseek(fd, 100, SEEK_SET) == -1)
		perror("lseek"), exit(1);

	n = strlen(buf2);
	if(write(fd, buf2, n) != n)
			perror("write"), exit(1);
	exit(0);
}
