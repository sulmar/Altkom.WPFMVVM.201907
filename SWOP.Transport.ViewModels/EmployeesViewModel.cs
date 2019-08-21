using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SWOP.Transport.ViewModels
{
    public class EmployeesViewModel : ViewModelBase
    {
        public ICollection<Employee> Employees { get; set; }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();

                SendCommand?.OnCanExecuteChanged();
            }
        }

        public RelayCommand SendCommand { get; set; }
        public RelayCommand<string> PrintCommand { get; set; }

        private IEmployeeRepository employeeRepository;
        private Employee _selectedEmployee;

        public EmployeesViewModel(IEmployeeRepository employeeRepository, INavigationService navigationService)
        {
            this.employeeRepository = employeeRepository;

            SendCommand = new RelayCommand(() => Send(), () => CanSend());
            PrintCommand = new RelayCommand<string>(p => Print(p));

            this.Employees = employeeRepository.Get();

            Logger logger = new Logger();

            logger.Write = WriteTxt;
            logger.Write += WriteDb;
            logger.Write += Console.WriteLine;

            // logger.Write = null;

            if (logger.Write != null)
            {
                logger.Write.Invoke("Hello World");
            }

            //foreach (var employee in Employees)
            //{
            //    Policeman policeman = (Policeman)employee;

            //    policeman.Calculate();

            //    employee.Calculate();
            //}
        }

        private void WriteAzure(string message, int number)
        {

        }

        private void WriteTxt(string message)
        {
            Console.WriteLine($"text file {message}");
        }

        public void WriteDb(string message)
        {
            Console.WriteLine($"db {message}");
        }


        public void Send()
        {
            Console.WriteLine($"Sending to {SelectedEmployee.FirstName}");
        }

        public bool IsEmployeeSelected => SelectedEmployee != null;

        public Policeman SelectedPoliceman => SelectedEmployee as Policeman;

        public bool IsPolicemanSelected => SelectedPoliceman != null;

        public bool CanSend()
        {
            return 
                IsPolicemanSelected &&
                SelectedPoliceman.Grade == Grade.Komisarz;
        }

        private void Print(string number)
        {

        }
    }
}
