using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //string cns = @"data source=(LocalDb)\MSSQLLocalDB;initial catalog=WindowsFormsApplication1.PersonContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        List<Person> people = new List<Person>();
        List<Adress> adressList = new List<Adress>();
        List<Phone> phoneList = new List<Phone>();

        Person SelectedPerson = null;
        Adress SelectedAdress = null;
        Phone SelectedPhone = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadContacts();
        }

        private void LoadContacts()
        {
            lstContacts.Items.Clear();
            //people.Clear();
            //phoneList.Clear();
            //adressList.Clear();

            using (var db = new PersonContext())
            {
                var adresses = (from a in db.Adresses
                                orderby a.AdressID
                                select a).ToArray();

                var phones = (from ph in db.Phones
                              orderby ph.PhoneID
                              select ph).ToArray();

                var persons = (from p in db.Persons
                               orderby p.PersonID
                               select p).ToArray();

                foreach (var item in persons)
                {
                    lstContacts.Items.Add(item);
                    people.Add(item);
                }
                foreach (var item in adresses)
                {
                    adressList.Add(item);
                }
                foreach (var item in phones)
                {
                    phoneList.Add(item);
                }
            }
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            using (var db = new PersonContext())
            {
                var person = new Person
                {
                    Name = txtName.Text,
                    Email = txtEmail.Text,
                    PersonAdress = adressList,
                    PersonPhone = phoneList
                };

                people.Add(person);
                db.Persons.Add(person);

                var adress = new Adress
                {
                    Home = txtStreetAdress1.Text,
                    Work = txtStreetAdress2.Text,
                    Other = txtStreetAdress3.Text,
                    City = txtCity.Text
                };

                adressList.Add(adress);
                db.Adresses.Add(adress);

                var phoneNr = new Phone
                {
                    Home = txtPhoneNr1.Text,
                    Cellphone = txtPhoneNr2.Text,
                    Other = txtPhoneNr3.Text
                };

                phoneList.Add(phoneNr);
                db.Phones.Add(phoneNr);

                db.SaveChanges();

                lstContacts.Items.Add(person.Name);
            }

            txtName.Clear();
            txtCity.Clear();
            txtPhoneNr1.Clear();
            txtPhoneNr2.Clear();
            txtPhoneNr3.Clear();
            txtEmail.Clear();
            txtCity.Clear();
            txtStreetAdress1.Clear();
            txtStreetAdress2.Clear();
            txtStreetAdress3.Clear();

            LoadContacts();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new PersonContext())
                {
                    SelectedPerson = (Person)lstContacts.SelectedItem;
                    var selectedPersonID = SelectedPerson.PersonID;

                    var p = db.Persons.Find(selectedPersonID);
                    SelectedAdress = p.PersonAdress.FirstOrDefault();
                    SelectedPhone = p.PersonPhone.FirstOrDefault();

                    var deletedPerson = db.Persons.Find(SelectedPerson.PersonID);
                    var deletedAdress = db.Adresses.Find(SelectedAdress.AdressID);
                    var deletedPhone = db.Phones.Find(SelectedPhone.PhoneID);

                    db.Persons.Remove(deletedPerson);
                    db.Adresses.Remove(deletedAdress);
                    db.Phones.Remove(deletedPhone);

                    db.SaveChanges();

                    lstContacts.Items.Remove(SelectedPerson.Name);
                }
            }

            catch { }

            LoadContacts();
        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new PersonContext())
            {
                SelectedPerson = (Person)lstContacts.SelectedItem;
                var selectedPersonID = SelectedPerson.PersonID;

                //var selectedAdress = SelectedPerson.PersonAdress;

                //var selectedPhone = SelectedPerson.PersonPhone;

                var p = db.Persons.Find(selectedPersonID);
                SelectedAdress = p.PersonAdress.FirstOrDefault();
                SelectedPhone = p.PersonPhone.FirstOrDefault();

                try
                {
                    txtName.Text = SelectedPerson.Name;
                    txtEmail.Text = SelectedPerson.Email;
                    txtCity.Text = SelectedAdress.City;

                    txtStreetAdress1.Text = SelectedAdress.Home;
                    txtStreetAdress2.Text = SelectedAdress.Work;
                    txtStreetAdress3.Text = SelectedAdress.Other;

                    txtPhoneNr1.Text = SelectedPhone.Home;
                    txtPhoneNr2.Text = SelectedPhone.Cellphone;
                    txtPhoneNr3.Text = SelectedPhone.Other;
                }

                catch { }
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtCity.Clear();
            txtPhoneNr1.Clear();
            txtPhoneNr2.Clear();
            txtPhoneNr3.Clear();
            txtEmail.Clear();
            txtCity.Clear();
            txtStreetAdress1.Clear();
            txtStreetAdress2.Clear();
            txtStreetAdress3.Clear();
        }
    }
}
