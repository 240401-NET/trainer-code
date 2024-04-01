# Bash, Git

## Bash

- GUI: Graphical User Interface
- CLI: CommandLine Interface- it is just a way for us to interact with machines (mine and others) and different software installed in those machines in text-based commands
- Bash: Bourne Again Shell Bash is one of the default shells (Terminal in Linux Terms) for Unix based OS's Git bash is an Emulator for bash

### Terminal Commands
- ls: LiSt contents of a folder
- cd: Change Directory
- ~ is a shorthand for a home directory
- / is the root directory
- . stands for the current directory
- .. stands for the parent directory
- mkdir: MaKe DIRectory
- touch: creates a new file
- nano: command line text editor, use this to modify existing text files and create new text files.
- rm: ReMoves a file or an entire folder (or a file tree)
- cat: to conCATenate content of a text file to the console (IE, printing a file's content to screen)
- mv: to MoVe files mv oldfile newfileLocation/filename.extension
- cp: CoPy

### Flag/Option
Flag, or option, is an optional parameter you can pass in with the command to provide additional information or trigger alternate behavior. For example, use rm with -r flag to delete folders!

### Additional commands of interest
- echo: To print to console
- grep: super nice for filtering results/searching file
- find: also similar to grep with a bit more feature
- which: which shows you where the software is located


## git
Git is a version control system, to be more precise, it's a distributed version control system, meaning everybody has their own copy of the repository

Basically, git is a way for software devs to back up our work and collaborate with others

### Source Code
Source code is your program/project

### Repository
Git repository or repo is source code plus the history of changes you've made
It is also a folder that contains .git hidden folder.
### Basic Git Workflow
1. make changes
2. Add to the staging area using `git add file-or-folder-name`
3. Commit with a meaningful message (For future you and your teammates) using `git commit -m "message here"`

- to view your staging area, use git status

### Working with Remote Repositories
- Add a new remote repository to your local repo by executing `git remote add nickname repo-url`
- Push your updates by `git push`
- Pull the updates from remote repo by `git pull`
- Download/Copy the new remote repo to your local machine by running `git clone repo-url` (this is the way to go, if you already have remote repository set up)

### Gitignore
.gitignore file is a file telling git to ignore certain files/folders and do not track/add these to the repository.
`dotnet new gitignore` at the root of your repository

### Branching
- `git branch` : displays all your LOCAL repository branches
- `git switch branch-name`: Move to a different branch. Make sure you don't have any uncommitted changes
- `git log`: gives you the commit history of the particular branch
- `git branch branch-name`: creates a new branch
- `git merge b`: merge commits from b branch into your current branch
- `git branch -d branch-name`: to delete branch

### Merge Conflict
This is git's way of saying that there are changes occurred in the same location of the same file, and it needs human intervention/review to see what to keep.
In order to resolve merge conflicts, review them and then choose which to keep, then add/commit.

### Oops, I committed and pushed stuff to remote repository I didn't mean to
1. `git rm --cached the-file-you-want-it-gone`: This is remove the file from the git repository, while leaving the file in the file system.
1a. `git rm -r --cached folder-you-want-it-gone` to remove folders from git repository
2. Fix your gitignore
3. add and commit your changes
4. push the changes to your remote repository
5. profit