#include <sys/types.h>
#include <unistd.h>
#include <stdlib.h>
#include <stdio.h>
#include <pwd.h>

int main(int argc, char *argv[], char* envp[])
{
        struct passwd *pw;
	char pw_entry[256];

	if(argc != 2)
		printf("Usage: %s <username>\n", argv[0]), exit(0);

	if((pw = getpwnam(argv[1])) == NULL)
		perror("getpwnam"), exit(1);

	printf("username = %s\n", pw->pw_name);
	printf("UID = %u\n", pw->pw_uid);
	printf("GID = %u\n", pw->pw_gid);
	printf("gecos = %s\n", pw->pw_gecos);
	printf("home_directory = %s\n", pw->pw_dir);
	printf("shell = %s\n", pw->pw_shell);
	
	exit(0);
}
