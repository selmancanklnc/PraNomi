using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PraNomi.Models;
using PraNomi.ViewModels;
using PraNomi.ViewMdoel;
using PraNomi.Views;

namespace PraNomi.ViewMdoel
{
    public class MyListViewModel
    {   
        public ObservableCollection<MyListModel> MyListCollector { get; set; }

        public MyListViewModel()
        {

            MyListCollector = new ObservableCollection<MyListModel>()
            {
                new MyListModel(){ MyName="Alexa" , MyDetail="Popular amongst literary  " , Image = "https://res.cloudinary.com/demo/image/upload/w_400,h_400,c_crop,g_face,r_max/w_200/lady.jpg" },
                new MyListModel(){ MyName="Amaya" ,   MyDetail="If you are lucky enough to beauty surrounding your home." , Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTr8hbJMPoCcTm9jss9otFgeL-zJx5Ve8mP1v3yq3oTl0FecoO6"},
                new MyListModel(){ MyName="Rose" , MyDetail="Giving the impression of an idyllic way of life. ",Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCTuJWZbbnmUl5HGDn7s0V40HTYjRZ8WCbkhU2M3flAg3k44DB"},
                new MyListModel(){ MyName="Benny" , MyDetail="Giving the impression of an idyllic way of life. ",Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq2AQqPeiJXiPjuos3LPJWTDJzv7Sq68ccRc7dUO3O1JXEbam0"},

                new MyListModel(){ MyName="Mary" , MyDetail="Popular amongst literary  " , Image = "https://res.cloudinary.com/demo/image/upload/w_400,h_400,c_crop,g_face,r_max/w_200/lady.jpg" },
                new MyListModel(){ MyName="Prexya" ,   MyDetail="If you are lucky enough to beauty surrounding your home." , Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTr8hbJMPoCcTm9jss9otFgeL-zJx5Ve8mP1v3yq3oTl0FecoO6"},
                new MyListModel(){ MyName="Suzan" , MyDetail="Giving the impression of an idyllic way of life. ",Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCTuJWZbbnmUl5HGDn7s0V40HTYjRZ8WCbkhU2M3flAg3k44DB"},
                new MyListModel(){ MyName="Saluz" , MyDetail="Giving the impression of an idyllic way of life. ",Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq2AQqPeiJXiPjuos3LPJWTDJzv7Sq68ccRc7dUO3O1JXEbam0"},

                new MyListModel(){ MyName="Suzan" , MyDetail="Popular amongst literary  " , Image = "https://res.cloudinary.com/demo/image/upload/w_400,h_400,c_crop,g_face,r_max/w_200/lady.jpg" },
                new MyListModel(){ MyName="Pikasa" ,   MyDetail="If you are lucky enough to beauty surrounding your home." , Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTr8hbJMPoCcTm9jss9otFgeL-zJx5Ve8mP1v3yq3oTl0FecoO6"},
                new MyListModel(){ MyName="Dispa" , MyDetail="Giving the impression of an idyllic way of life. ",Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCTuJWZbbnmUl5HGDn7s0V40HTYjRZ8WCbkhU2M3flAg3k44DB"},
                new MyListModel(){ MyName="Mae" , MyDetail="Giving the impression of an idyllic way of life. ",Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq2AQqPeiJXiPjuos3LPJWTDJzv7Sq68ccRc7dUO3O1JXEbam0"},

            };


        }


    }
}