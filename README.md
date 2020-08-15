# PortFail2Ban
A simple but powerful tool to prevent brute force attach for remote desktop or ssh, etc
Support Windows 7 / Windows Server 2003 or higher

Required:
  Windows Firewall MUST be enabled.
  需要Windows防火墙支持

# 原理
对于远程桌面、SSH等端口，属于高敏感度、低连接密度的端口，因此不可能有大量的重复连接，而暴力破解密码的时候，一般黑客利用的是肉鸡代理，控制大量IP不断重复拆解密码，经常会出现几分钟内大量IP不断重复连接，因此我们完全可以利用该特点检测不断重连的IP然后在防火墙上封锁。

# 保护端口
需要保护的目标端口，远程桌面默认是 3389 。如果是SSH，默认是 22。

# 触发次数
当黑客通过同一个IP连续连接多少次，就直接封锁对应IP。

# 封锁时长
当封锁某个IP后，多久时间解锁该IP。

# 清理间隔
当正常的IP的连接被检测到之后，多久时间重置该IP连接信息。
