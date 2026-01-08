#  Hell Kitchen (Overcooked-like Game)

**Hell Kitchen** là một game 3D/2.5D lấy cảm hứng từ **Overcooked**, được phát triển bằng **Unity**.  
Người chơi điều khiển nhân vật trong nhà bếp, thực hiện các thao tác nấu ăn, chế biến món và phục vụ đúng yêu cầu trong thời gian giới hạn.

Dự án tập trung vào gameplay tương tác, quản lý trạng thái game và tư duy kiến trúc code trong Unity.

---

##  Gameplay

- Điều khiển nhân vật di chuyển trong khu vực bếp
- Tương tác với các vật thể: nguyên liệu, bàn bếp, dụng cụ nấu ăn
- Chế biến món ăn theo thứ tự yêu cầu
- Phục vụ món đúng để ghi điểm
- Game kết thúc khi hết thời gian hoặc không hoàn thành yêu cầu

---

##  Features

- Điều khiển nhân vật bằng bàn phím
- Hệ thống tương tác (Interact System)
- Logic chế biến món ăn theo từng bước
- Quản lý trạng thái món ăn (raw → cooked → served)
- Gameplay loop rõ ràng
- Dễ mở rộng cho nhiều món và nhiều level

---

##  Công nghệ sử dụng

- **Engine:** Unity 2022.3.62f3
- **Ngôn ngữ:** C#  
- **Thể loại:** Simulation / Casual / Cooking Game  

---

##  Cấu trúc thư mục chính

```text
Assets/
├── Scripts/            # Gameplay logic, player, kitchen system
├── Prefabs/            # Nhân vật, vật thể tương tác
├── Scenes/             # Scene game
├── Art/                # Model, material, sprite
├── Animations/         # Animation cho nhân vật / object
└── Audio/              # Âm thanh
````

---

##  Cách chạy dự án

1. Cài đặt **Unity Hub**
2. Mở Unity Hub → **Open Project**
3. Chọn thư mục `Hell_Kitchen`
4. Mở scene chính trong thư mục `Scenes`
5. Nhấn **Play** để chạy game

> Khuyến nghị: Unity LTS version

---

##  Mục tiêu của dự án

* Thực hành lập trình gameplay với **Unity & C#**
* Rèn luyện tư duy OOP và kiến trúc code trong game
* Xây dựng hệ thống tương tác linh hoạt
* Làm dự án portfolio phục vụ xin **Intern Unity Developer**

---

##  Ghi chú

Đây là dự án học tập cá nhân, tập trung vào gameplay core.
Trong tương lai có thể mở rộng thêm:

* Nhiều món ăn và công thức hơn
* Nhiều level với độ khó tăng dần
* UI order / timer / score
* AI NPC hoặc chế độ co-op

---
