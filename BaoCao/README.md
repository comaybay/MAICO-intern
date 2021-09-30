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

