# GAME EDUCATION

### **1. Introduction:** Giới thiệu khái quát

- Tên nhóm: **AntiHacker** (Hoàng Ngọc Dung, Huỳnh Mạnh Tường, Nguyễn Phúc Bình, Đào Phúc Thịnh)

- Chủ đề nhóm hướng đến **Technology - Enhancing Education for Young Minds** : Tăng cường sự hiệu quả trong học tập và mang lại giáo dục toàn diện cho học sinh.

- Tên sản phẩm: `AntiHacker.exe`

### **2. Inspiration:** Cảm hứng tạo ra sản phẩm

Trong qua trình công nghiệp hóa hiện đại hóa bùng nổ như hiện nay. Song hành với sự **phát triển công nghệ** chính là **vấn đề bảo mật thông tin.** Chính vì vậy, nhóm em quyết định phát triển theo hướng **Enhancing Education for Young Minds** nhằm mong muốn thông qua trò chơi (game 2d platformer) kết hợp với các vấn về như *Networking*, *Phishing*, *Privacy* giúp cho mọi người có cái nhìn toàn diện hơn về các vấn đề liên quan đến bảo mật và nâng cao thêm nhân thức với những vấn đề liên quan.

Ngoài ra, **CTF(Capture The Flag)** một cuộc thi kiến ​​thức chuyên sâu về bảo mật máy tính. Đây chính là nguồn cảm hứng thúc đẩy nhóm em mô phỏng các kiến thức cũng như thử thách liên quan đến bảo mật.

### **3. What it does:** Chức năng chính của sản phẩm

Tựa game của nhóm em sẽ gồm một nhân vật có khả năng di chuyển vượt chướng ngại vật. Khi nhân vật chạm vào quái vật thì người chơi phải trả lời câu hỏi liên quan đến các kiến thức liên quan đến bảo mật thông tin. Kiến thức cung cấp sẽ được mô hình hóa dưới dạng sơ đồ tư duy hoặc mang hướng tiếp cận qua bài Blog. Đồng thời người chơi có thể lựa chọn làm bài quiz nhỏ sau khi học kiến thức mới.

### **4. How we build it:** Quá trình tạo nên sản phẩm

- **Giai đoạn đầu** : nhóm em lên ý tưởng và bàn bạc về theme cho game, các thao tác cho nhân vật, thứ tự hiện thị câu hỏi và thu thập các kiến thức về an ninh mạng bảo mật thông tin.

- **Giai đoạn thực hiện** : Nhóm em sử dụng github để push code cũng như mọi người dễ theo dõi và xem xét. 

    - Nhóm coder: Nhóm em chia phần câu hỏi và thao tác nhân vật sau đó gộp lại. Các hoạt thao tác về game nhóm em dùng state để quản lý cũng như truy vấn. Cuối cùng bàn bạc với nhau và xử lý các vấn đề liên quan đến code / kĩ thuật.

    - Nhóm desgin UI: Thống nhất chủ đề , sound track, effect cho nhóm. Thiết kế tất cả UI cho gameplay.

    - Ban đầu game có thiên hướng về kỹ năng hơn kiến thức. Tuy nhiên vào giai đoạn sau nhóm em đã cung cấp kiến thức cho người chơi và cái quiz nhỏ.

- **Giai đoạn hoàn thiện**: Phân chia thuyết trình , build unity ra game desktop. Hoàn thiện report và kiểm tra game.

### **5. Challenges:** Khó khăn trong khi tạo ra sản phẩm

Thời gian đầu làm việc nhóm em gặp vấn đề trong việc thống nhất ý tưởng, style code khác nhau. 
### **6. Accomplishments:** Các thành công đã đạt được

Nhóm em đã hoàn toàn được trải nghiệm và thử thách bản thân trong việc thiết kế làm prototype về game từ những ý tưởng ban đầu. Từ đó có thêm góc nhìn mới về vấn đề áp dụng game vào giáo dục. Mang lại sự cân bằng trong việc chơi và học

### **7. Lessons learned:** Bài học rút ra trong quá trình làm

- **Teamwork**: Tiếp xúc ,làm việc với nhau giúp tụi em có thêm kĩ năng phản biện, hỗ trợ góp ý cũng như khả năng làm việc nhóm hiệu quả hơn sau này.

- **Unity**: Khám phá một lĩnh vực mới giúp chúng em thử thách giới hạn bản thân và rút ra các bài học như. Thống nhất bản unity để không mất package và conflict code. Thống nhất việc load scene và state chuyển đổi và một số thứ liên quan đến việc code c#.

- **Github**: Chia branch làm việc hiểu quả hơn, merge code giữa các branch , xử lý conflict. 

### **8. Future:** Kế hoạch cải tiến và phát triển sản phẩm

- **Nội dung**

    - Phát triển thêm cốt truyện thông qua từng round. Trong quá trình vượt thử thách sẽ có những kiến thức được cung cấp giúp trả lời câu hỏi trong phần tiếp theo. Đồng thời xây dựng những round game theo thử thách ctf ví dụ (*tìm flag thông qua các chall hoặc mô phỏng các hint như chall osint, forensic ctf để người chơi submit flag*). Ngoài ra, thêm nhiều câu hỏi hơn về các vấn đề liên quan đến an ninh mạng như điều tra số (**digital forensic**), **mics** cũng tăng số lượng câu về privacy, phishing, networking.

- **Kĩ thuật** 

    - Hiện thị câu hỏi ngẫu nhiên theo quy luật nào đó (như xác suất posion, fibonaci). Nếu người chơi không trả lời sai sẽ mất mạng hoặc quay về checkpoint. Phân loại câu hỏi theo các chủ đề.

    - Respondsive screen cho nhiều thiết bị (androi), up game lên itch.io.Cải thiện gameplay, fix bug

    - Thêm soundtrack, sound effect cho hiệu ứng như nhảy, chạm đất. Cho phép chọn các nhân vật khác nhau, cho phép chọn độ khó(dễ thường khó. Thêm các kẻ địch cùng nhiều cơ chế di chuyển khác
### **9. Source code**

[Link github](https://github.com/QuizGameTeam/QuizGame_SteamRound2/tree/main)



