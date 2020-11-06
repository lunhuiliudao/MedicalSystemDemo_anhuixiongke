$.ajaxSetup({
    error: function (XMLHttpRequest, textStatus, errorThrown) {
        if (XMLHttpRequest.status == 403) {
            alert('您没有权限访问此资源或进行此操作');
            return false;
        }
    },
    complete: function (XMLHttpRequest, textStatus) {
        var sessionstatus = XMLHttpRequest.getResponseHeader("sessionstatus"); //通过XMLHttpRequest取得响应头,sessionstatus， 
        if (sessionstatus == 'timeout') {
            //如果超时就处理 ，指定要跳转的页面  
            var top = getTopWinow(); //获取当前页面的顶层窗口对象
            alert('登录超时, 请重新登录.');
            top.location.href = path + "/login/Index"; //跳转到登陆页面
        }
    }
});
// 首页加载完后，取消加载中状态
window.onload = function () {
    $("#loading").fadeOut();
}

function addTab(li,title, url) {
    if ($('#center').tabs('exists', title)) {
        $('#center').tabs('select', title);
    } else {
        var content = '<iframe scrolling="auto" frameborder="0" src="' + url + '" style="width:100%;height:100%;"></iframe>';
        $('#center').tabs('add', {
            title: title,
            content: content,
            closable: true
        });
    }
    $("#left_memu li").removeClass("menuli");
    $(li).parent().addClass("menuli");
}

function modifyPwd() {
    $("#pwdDialog").window('open');
};

// 退出系统
function logout() {
    $.messager.confirm('提示', '确定要退出吗?', function (r) {
        if (r) {
            window.location.href = '/login/LoginOut'
        }
    });
}

function date(val) {
    if (val != null) {
        var date = new Date(parseInt(val.replace("/Date(", "").replace(")/", ""), 10));
        //月份为0-11，所以+1，月份小于10时补个0
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        return date.getFullYear() + "-" + month + "-" + currentDate;
    }
    return "";
}

function dateTime(val) {
    if (val != null) {
        var date = new Date(parseInt(val.replace("/Date(", "").replace(")/", ""), 10));
        //月份为0-11，所以+1，月份小于10时补个0
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        return date.getFullYear() + "-" + month + "-" + currentDate +" "+date.getHours()+":"+date.getMinutes();
    }
    return "";
}

$.extend($.fn.textbox.defaults.rules, {  
    number: {  
        validator: function(value, param) {  
            return /^[0-9]*$/.test(value);  
        },  
        message: "请输入数字"  
    },
    chinese: {  
        validator: function(value, param) {  
            var reg = /^[\u4e00-\u9fa5]+$/i;  
            return reg.test(value);  
        },  
        message: "请输入中文"  
    },  
    nochinese: {  
        validator: function(value, param) {  
            var reg1 = /.*[\u4e00-\u9fa5]+.*/i;  
            var reg2 = new RegExp("[！￥（）【】；：、？，。]");  
            return ! reg1.test(value) && !reg2.test(value);  
        },  
        message: "不允许输入中文字符"  
    },  
    nofullWidthCharacter: {  
        validator: function(value, param) {  
            var reg = /.*[\uff00-\uffff]+.*/i;  
            return ! reg.test(value);  
        },  
        message: "不允许输入全角字符"  
    },      
    checkLength: {  
        validator: function(value, param) {  
            return param[0] >= value.length;  
        },  
        message: '请输入最大{0}位字符'  
    },  
    specialCharacter: {  
        validator: function(value, param) {  
            var reg = new RegExp("[`~!@#$^&*()=|{}':;'\\[\\]<>~！@#￥……&*（）——|{}【】‘；：”“'、？]");  
            return ! reg.test(value);  
        },  
        message: '不允许输入特殊字符'  
    },  
    englishLowerCase: {  
        validator: function(value) {  
            return /^[a-z]+$/.test(value);  
        },  
        message: '请输入小写字母'  
    },
    englishNumber: {
        validator: function (value) {
            return /^[a-zA-Z0-9]+$/.test(value);
        },
        message: '请输入字母或数字'
    }
});
function checkbox(obj) {
    if (obj.checked) {
        obj.value = 1;
    } else {
        obj.value = 0;
    }
}

