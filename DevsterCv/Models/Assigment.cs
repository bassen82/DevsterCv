using DevsterCv.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace DevsterCv.Models
{
    public class Assigment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Employeeid { get; set; } 
        public string Uppdrag { get; set; } = string.Empty;
        public string Tid { get; set; } = string.Empty;
        public string Roll { get; set; } = string.Empty;
        public string Beskrivning { get; set; } = string.Empty;
        public string Teknik { get; set; } = string.Empty;
        public bool Focus { get; set; }

        public Assigment(int employeeid, string uppdrag, string roll, string tid, string beskrivning, string teknik, bool focus)
        {
            Employeeid = employeeid;
            Uppdrag = uppdrag;
            Tid = tid;
            Roll = roll;
            Beskrivning = beskrivning;
            Teknik = teknik;
            Focus = focus;
        }

        public Assigment()
        {
        }

        public List<AssignmentViewModel> GetAllNonFocusAssignments(int employee)
        {
            List<AssignmentViewModel> AssignmentViewModels = new List<AssignmentViewModel>();

            List<Assigment> targetData = AssignmentService.GetAllNonFocus(employee);

            if (targetData != null)
            {
            foreach (Assigment target in targetData)
            {
                AssignmentViewModel avm = new AssignmentViewModel
                {
                    Id = target.Id,
                    Beskrivning = target.Beskrivning,
                    Roll = target.Roll,
                    Teknik = target.Teknik,
                    Tid = target.Tid,
                    Uppdrag = target.Uppdrag,
                    Focus = target.Focus
                };

                AssignmentViewModels.Add(avm);
            }
            }

            return AssignmentViewModels;
        }

        public List<FocusAssignmentViewModel> GetAllFocusAssignments(int employee)
        {
            List<FocusAssignmentViewModel> FocusAssignmentViewModels = new List<FocusAssignmentViewModel>();
            List<Assigment> targetData = AssignmentService.GetAllFocus(employee);
            if (targetData!=null)
            {
            foreach (Assigment target in targetData)
            {
                FocusAssignmentViewModel favm = new FocusAssignmentViewModel
                {
                    Id = target.Id,
                    Beskrivning = target.Beskrivning,
                    Roll = target.Roll,
                    Teknik = target.Teknik,
                    Tid = target.Tid,
                    Uppdrag = target.Uppdrag,
                    Focus = target.Focus
                };
                FocusAssignmentViewModels.Add(favm);
            }
            }
            return FocusAssignmentViewModels;
        }

        public List<AssignmentViewModel> GetAllAssignments(int employee)
        {
            List<AssignmentViewModel> AssignmentViewModels = new List<AssignmentViewModel>();

            List<Assigment> targetData = AssignmentService.GetAll(employee);

            if (targetData != null)
            {
                foreach (Assigment target in targetData)
                {
                    AssignmentViewModel avm = new AssignmentViewModel
                    {
                        Id = target.Id,
                        Beskrivning = target.Beskrivning,
                        Roll = target.Roll,
                        Teknik = target.Teknik,
                        Tid = target.Tid,
                        Uppdrag = target.Uppdrag,
                        Focus = target.Focus
                    };

                    AssignmentViewModels.Add(avm);
                }
            }
            return AssignmentViewModels;
        }

        public AssignmentViewModel GetView(Assigment target)
        {
            Employee employee = EmployeeService.Get(target.Employeeid);
            AssignmentViewModel avm = new AssignmentViewModel
            {
                Id = target.Id,
                Employee = employee,
                Beskrivning = target.Beskrivning,
                Roll = target.Roll,
                Teknik = target.Teknik,
                Tid = target.Tid,
                Uppdrag = target.Uppdrag,
                Focus = target.Focus
            };

            return avm;
        }




    }
}
