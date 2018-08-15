using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class MVC
{
    public static Dictionary<string, Model> Models = new Dictionary<string, Model>();
    public static Dictionary<string, View> Views = new Dictionary<string, View>();
    public static Dictionary<string, Type> Controllers = new Dictionary<string, Type>();

    //注册Model、View、Controller
    public static void RegisterModel(Model model)
    {
        Models[model.Name] = model;
    }

    public static void RegisterView(View view)
    {
        //防止重复注册
        if (Views.ContainsKey(view.Name))
        {
            return;
        }
        view.RegisterEventList();
        Views[view.Name] = view;
    }

    public static void RegisterController(string eventName,Type controllerType)
    {
        Controllers[eventName] = controllerType;
    }

    //获取
    public static T GetModel<T>()
        where T : Model
    {
        foreach (var m in Models.Values)
        {
            if (m is T)
                return m as T;
        }
        return null;
    }

    public static T GetView<T>()
        where T : View
    {
        foreach (var v in Views.Values)
        {
            if (v is T)
                return v as T;
        }
        return null;
    }

    //事件发送
    public static void SendEvent(string eventName,object data = null)
    {
        //Controller执行
        if (Controllers.ContainsKey(eventName))
        {
            Type t = Controllers[eventName];
            Controller controller = Activator.CreateInstance(t) as Controller;
            controller.Execute(data);
        }
        //View处理
        foreach(var v in Views.Values)
        {
            if (v.eventList.Contains(eventName))
            {
                v.HandleEvent(eventName, data);
            }
        }
    }
}
