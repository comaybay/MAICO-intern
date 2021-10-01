# Báo cáo: lộ trình học "nhập môn Blazor" và "Blazor nâng cao"

Em sẽ bắt đầu học Blazor bằng video này trên youtube: [Blazor Course - Use ASP.NET Core to Build Full-Stack C# Web Apps](https://youtu.be/4G_BzLxa9Nw).

Cùng với đó là trang [Blazor University](https://blazor-university.com/).

Những kiến thức video không giảng (hoặc nếu không giải thích đủ rõ) thì em sẽ tìm kiếm trên các tài liệu khác và báo cáo ở đây.

# Blazor

Là một framework cho phép tạo web app sử dụng C# và HTML.

# Giới thiệu chung về kiến trúc Blazor (Blazor Architecture Overview)

Trong lập trình web, ta có hai loại kiến trúc thường thấy:

## Client–server model

Request - Response model là phương thức trao đổi giữa 2 máy thông qua việc 1 máy gửi request đến 1 máy khác và máy đó sẽ trả lời (response) lại request được nhận bằng cách gửi response lại cho máy gửi request

Client-server model sử dụng phương thức này để liên lạc giữa client và server, trong đó client sẽ là máy gửi request, còn server là máy gửi response.

Ví dụ trong trường hợp sử dụng internet để lướt web: Client sẽ là trình duyệt web của người sử dụng, gửi request yêu cầu tài nguyên nào đó (html, file ảnh, ...), Server sẽ là hệ thống nhận request và trả về tài nguyên mà client yêu cầu.

## Rest API

Thay vì phải gửi cả một trang web đã được tạo sẵn hoặc tính toán từ server, server sẽ gửi tài nguyên cần thiết để để client tự tạo nên trang web sử dụng javascript, và client sẽ tương tác với server thông qua REST API để nhận tài nguyên cần thiết (thường ở dạng JSON) để thay đổi trang web được thấy từ phía client.

Blazor một kiểu kiến trúc riêng:

## Blazor

Giống như Rest API nhưng thay vì sử dụng javascript bên client để tạo trang, client sử dụng C#! Điều này nghĩa là ta có thể code cả bên front-end và back-end sử dụng cùng một loại ngôn ngữ.

# Hai loại Hosting Models

## Blazor WebAssembly

App Blazor sẽ được chạy từ phía client trên trình duyệt thông qua một .NET runtime dựa trên WebAssembly. App Blazor và các dependency của nó và .NET runtime sẽ được tải xuống trình duyệt người dùng và được chạy trực tiếp từ phía người dùng. Assets mà app cần sẽ do web server cung cấp ở dạng static file.

Ưu điểm:

1. Có thể chạy app được dù offline (nhưng không tương tác với server được),
2. Giảm công việc cho server

Nhược điểm:

1. Do phải tải cả runtime, app Blazor và dependency của nó cho nên lần đầu người dùng chạy app sẽ chậm hơn so với việc chạy app server-side (Blazor Server)
2. Hiện tại .NET runtime dựa trên WebAssembly vẫn còn chạy chậm hơn việc chạy code C# bên server.

## Blazor Server

App Blazor sẽ được chạy bên trong app ASP.NET Core, việc cập nhật UI, event handling, Javascript calls sẽ được đẩy lên bên client thông qua SignalR connection.

Ưu điểm:

1. Do nội dung HTML được pre-render và gửi cho client, việc này giúp cho SEO.
2. Hỗ trợ chạy trên trình duyệt đời cũ (như Internet Explorer 11) không hỗ trợ WebAssembly.

Nhược điểm:

1. Bên server sẽ cấp bộ nhớ cho mỗi client và dùng SignalR để giao tiếp với client cho đến khi client dừng sử dụng app, điều này nghĩa là mỗi client sẽ phụ thuộc vào server mà nó giao tiếp, càng nhiều client trong cùng một thời điểm thì server càng tốn nhiều bộ nhớ.
