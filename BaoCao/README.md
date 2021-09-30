# Tạo repository

## Tạo từ directory trên máy

1. Đi đến directory của repository cần tạo.
2. Tạo repository bằng cách nhập câu lệnh `git init` vào terminal. Việc này tạo ra folder .git, git dùng nó để quản lý repository được tạo.
3. Bắt đầu làm việc, add file, commit, ...
4. Để host repository lên trên internet thì tùy vào mỗi trang host, đối với github, xem [link này](https://docs.github.com/en/github/importing-your-projects-to-github/importing-source-code-to-github/adding-an-existing-project-to-github-using-the-command-line).

## Clone repository sẵn có trên internet (remote repository)

1. Đi đến directory của repository muốn clone.
2. nhập `git clone <url>`. Việc này sẽ tạo một folder với tên của repository được clone, trong đó là folder .git và tất cả các data của repository đó.
3. Bắt đầu làm việc, add file, commit, ...

# Tạo và checkout branch

Nhập câu lệnh `git branch <tên branch>`. Nó sẽ tạo branch từ commit mà bạn hiện đang ở.

Để chuyển sang branch mới tạo (hay một branch nào đó), nhập `git checkout <tên branch>`

> Để tiện cho việc muốn tạo branch mới và di chuyển sang branch đó luôn, ta có thể nhập `git checkout -b <tên branch>` để thực hiện cả hai việc trên cùng một lúc.

# Thao tác stage

Sau khi đã làm việc (tạo ra/sửa/xóa các file trong repository trên máy), để có thể đẩy nó lên remote repository, trước tiên ta cần phải cho git biết các file mà bạn đẩy lên, việc này gọi là 'staging'.

Để stage một file, ta nhập `git add <tên file>`, nếu file ở trong folder nào đó thì ta nhập `git add <path đến file>`

Để stage tất cả các thay đổi (tạo/sửa/xóa) thì ta có thể nhập `git add -A` hoặc `git add .` (đối với Git từ phiên bản 2.0)

# Thao tác commit

Các file được đã được stage có thể được ghi lại thành một "sự kiện đã xảy ra" trong lịch sử của branch của repository, được gọi là một 'commit', và lịch sử đó được gọi là 'commit history'.

Để tạo commit, ta nhập `git commit`, các thay đổi được stage sẽ được ghi lại trong commit này. Một editor (trong ví dụ phía dưới là Vim) sẽ hiện lên, với các dòng tương tự như sau:

```
# Please enter the commit message for your changes. Lines starting
# with '#' will be ignored, and an empty message aborts the commit.
# On branch master
# Your branch is up-to-date with 'origin/master'.
#
# Changes to be committed:
#	new file:   README
#	modified:   CONTRIBUTING.md
#
~
~
~
".git/COMMIT_EDITMSG" 9L, 283C`
```

Ở ví dụ này, commit này sẽ ghi lại hai file: README (mới tạo) và CONTRIBUTING.md (được sửa). Bạn có thể xóa các dòng này đi (hoặc giữ lại nếu muốn, dòng mở đầu bằng '#' sẽ bị bỏ qua) và ghi tên của commit này (ở dòng đầu tiên), lí giải cho commit này, v.v... (ở các dòng tiếp theo). Đây được gọi là 'commit message'.

Sau khi lưu lại và thoát khỏi editor, Git sẽ tạo commit này cùng với commit message đó.

Nếu commit message của bạn ngắn, bạn có thể tạo commit và nhập commit message cùng một lúc với câu lệnh `git commit -m "<message của commit này>"`

# Thao tác push

Sau khi commit thì các commit này chỉ có trong commit history của máy bạn, để đẩy nó lên remote repository, ta dùng câu lệnh `git push <remote> <branch>`. Việc này sẽ đẩy các commit mới của branch bạn lên branch của remote repository đó. Remote thường được đặt là 'origin' (khi clone repository trên github thì remote repository đó được đặt là 'origin').

# Thao tác pull

Khi làm việc với nhiều người trong cùng một remote repository, ta cần phải cập nhật repository trên máy của mình (để chứa các thay đổi mới của người khác trên remote repository), để cập nhật các thay đổi ta nhập `git pull <remote>`. Việc này sẽ lấy bản copy của branch mà bạn đang ở (lấy trên remote repository) và hợp nó với bản copy của bạn (trên máy bạn). Việc hợp 2 branch với nhau gọi là 'merge'.

Ngoài ra `git pull --rebase` cũng hay được sử dụng, do khi pull git sẽ tạo một commit merge hai branch lại, dùng câu lệnh này để chuyển các commit mới từ máy bạn lên trên commit mới nhất của branch remote, việc này để tránh việc merge không cần thiết (giữ cho commit history được sạch).

