# EasyContral
![EasyContral](https://socialify.git.ci/Mangofang/EasyContral/image?description=1&forks=1&issues=1&language=1&logo=https%3A%2F%2Favatars.githubusercontent.com%2Fu%2F38810849%3Fv%3D4&name=1&owner=1&pattern=Circuit%20Board&pulls=1&stargazers=1&theme=Dark)

> C#编写的基于HTTP的远程控制程序

项目中`EasyContral`为被控端程序 `EasyContral_Server`为控制端程序

请自行编译修改被控端程序

如果你有任何问题或反馈程序问题请提交`Issues`

<img src="https://github.com/user-attachments/assets/e043c2f4-8c09-4153-b8b3-34b39f282091" width="50%">

## 声明：
1. 文中所涉及的技术、思路和工具仅供以安全为目的的学习交流使用，任何人不得将其用于非法用途以及盈利等目的，否则后果自行承担！
2. 水平不高，纯萌新面向Google编程借鉴了很多大佬的代码，请自行酌情修改

## 使用流程
添加URL ACL，管理员模式启动CMD：netsh http add urlacl url=http://+:4400/ user=Everyone

控制端默认监听`4400`端口，防火墙开放`4400`端口

修改被控端`Server_Ip`变量为控制端的地址，编译被控端

注意：被控端存在一个60秒的延迟执行反沙箱以及检测目标机器是否存在QQ和微信，可自行更改

## 通信流程：
参考Conbalt Strike的Http Beacon的通信过程，但较为简化

被控端间隔一个单位时间向服务端发送一次http请求

如果服务端有任务在序列中，即将任务信息写入返回的请求体中

被控端获取返回请求体并执行对应指令，并发送执行结果

<img src="https://github.com/user-attachments/assets/ee3e0e01-2b62-4e72-aee2-568e642b6b6f" width="50%">

## 已实现功能
1. CMD
<img src="https://github.com/user-attachments/assets/f17a3a4f-3e5f-4172-8d09-8ca15c107797" width="40%">

3. 文件管理（上传、下载、浏览目录）
<img src="https://github.com/user-attachments/assets/d675aaf1-9f2d-483f-8306-e4ff3e7c71f9" width="40%">

4. 屏幕监控
5. 进程管理（启动进程、关闭进程、查看进程）
6. 自启动
7. 键盘监听

## 更新

### 2025年1月22日

1.增加键盘监听

### 2025年1月17日

1.字符串加密

### 2024年12月29日

1.BUG修复

### 2024年11月11日

1.增加远程添加自启动功能

1.1. 计划任务自启动 √

1.2. 注册表自启动 √

2024年10月30日

1.公开仓库


## 可能的更新
1. 代码优化
