using QuestPDF.Helpers;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using IContainer = QuestPDF.Infrastructure.IContainer;
using QuestPDF.Drawing;
using ClinicManager.Shared.DTO_s;

namespace ClinicManager.Application.Helpers
{
    internal static class SimpleExtension
    {
        private static IContainer Cell(this IContainer container, bool dark)
        {
            return container
                .Border(0.75f)
                .Background(dark ? Colors.Grey.Lighten2 : Colors.White)
                .Padding(5);
        }

        public static void LabelCell(this IContainer container, string text) => container.Cell(true).Text(text, TextStyle.Default.Size(6));

        public static IContainer ValueCell(this IContainer container) => container.Cell(false);
    }
    public class PDFHelper : IDocument
    {
        public SubscriptionDTO _subscriptions { get; set; }


        public double subtotal = 0.00;

        public PDFHelper(SubscriptionDTO subscriptions)
        {
            _subscriptions = subscriptions ?? throw new ArgumentNullException(nameof(subscriptions));
        }
 

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    
    public void Compose(IDocumentContainer container)
    {
            string path = "https://medopsblob.blob.core.windows.net/medops-images/medopslogo.png";

            try
            {
            container
            .Page(page =>
            {
                page.Margin(50);

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);

                page.Footer().AlignCenter().Stack(stack =>
                {
                    //stack.Item().AlignCenter().Height(50).Width(100).Image(path, ImageScaling.FitArea);
                    stack.Item().AlignCenter().Text("www.medops.com", TextStyle.Default.Size(8).SemiBold());
                });
            });
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private void ComposeContent(IContainer container)
    {
        container.PaddingVertical(5).Stack(stack =>
        {
            stack.Item().Element(ComposeDetailsTable);
            //stack.Item().Element(ConditionsOfContract);
        });
    }

    private void ComposeHeader(IContainer container)
    {
        var titleStyle = TextStyle.Default.Size(12).SemiBold().Color(Colors.Black);

        container.Row(row =>
        {
            row.RelativeColumn().Stack(stack =>
            {
                stack.Item().Text($"Request - {_subscriptions.ReferenceNo} ", titleStyle);
            });

            row.ConstantColumn(100).Height(50).Stack(stack =>
            {
                stack.Item().ValueCell().Text(DateTime.Now.ToString("MMMM dd"), titleStyle);
            });
        });
    }

    private void ComposeDetailsTable(IContainer container)
    {
        var paragraphStyle = TextStyle.Default.Size(12).SemiBold().Color(Colors.Black);
        //string[] headerfields = { "One", "Two", "Three", "Four" };
        container.PaddingTop(10).Decoration(decoration =>
        {
            // header
            decoration.Content().BorderTop(10).BorderColor(Colors.Black).Row(row =>
            {
                row.RelativeColumn().Stack(stack =>
                {
                    stack.Item().Element(UserDetailsFrame1);
                });

                row.RelativeColumn().Stack(stack =>
                {
                    stack.Item().Element(UserDetailsFrame2);
                });
            });
        });
    }

        public void UserDetailsFrame1(IContainer container)
        {
            container
                .Background("#FFF")
                .Stack(stack =>
                {
                    stack.Item().Row(row =>
                    {
                        row.RelativeColumn(2).LabelCell("FIRST NAME:");
                        row.RelativeColumn(3).ValueCell().Text($"{_subscriptions.repFirstName}", TextStyle.Default.Size(6));
                    });

                    stack.Item().Row(row =>
                    {
                        row.RelativeColumn(2).LabelCell("LAST NAME:");
                        row.RelativeItem(3).ValueCell().Text($"{_subscriptions.repLastName}", TextStyle.Default.Size(6));
                    });

                    stack.Item().Row(row =>
                    {
                        row.RelativeColumn(2).LabelCell("EMAIL:");
                        row.RelativeColumn(3).ValueCell().Text($"{_subscriptions.Email}", TextStyle.Default.Size(6));
                    });

                    stack.Item().Row(row =>
                    {
                        row.RelativeColumn(2).LabelCell("CELL:");
                        row.RelativeColumn(3).ValueCell().Text($"{_subscriptions.MobileNo}", TextStyle.Default.Size(6));
                    });

                    stack.Item().Row(row =>
                    {
                        row.RelativeColumn(1).LabelCell("ADDRESS:");
                        row.RelativeColumn(1).ValueCell().Text($"{_subscriptions.ClinicAddress}", TextStyle.Default.Size(6));
                    });

                    stack.Item().Row(row =>
                    {
                        row.RelativeColumn(1).LabelCell("POSTAL CODE:");
                        row.RelativeColumn(1).ValueCell().Text($"{_subscriptions.PostalCode}", TextStyle.Default.Size(6));
                    });

                    stack.Item().Row(row =>
                    {
                        row.RelativeColumn(1).LabelCell("CITY:");
                        row.RelativeColumn(1).ValueCell().Text($"{_subscriptions.City}", TextStyle.Default.Size(6));
                    });

                    stack.Item().Row(row =>
                    {
                        row.RelativeColumn(1).LabelCell("PROVINCE:");
                        row.RelativeColumn(1).ValueCell().Text($"{_subscriptions.Province}", TextStyle.Default.Size(6));
                    });
                });
        }

        public void UserDetailsFrame2(IContainer container)
        {
            container
                .Background("#FFF")
                .Stack(stack =>
                {
                    stack.Item().Row(row =>
                    {
                        row.RelativeColumn(5).LabelCell("AMOUNT OF NURSES:");
                        row.RelativeColumn(3).ValueCell().Text($"{_subscriptions.AmountOfNurses}", TextStyle.Default.Size(6));
                    });

                    stack.Item().Row(row =>
                    {
                        row.RelativeColumn(2).LabelCell("STORAGE PLAN:");
                        row.RelativeColumn(3).ValueCell().Text($"{_subscriptions.StoragePlan}", TextStyle.Default.Size(6));
                    });

                    stack.Item().Row(row =>
                    {
                        row.RelativeColumn(2).LabelCell("PRICE PER NURSE:");
                        row.RelativeColumn(3).ValueCell().Text($"R{_subscriptions.PricePerNurse}", TextStyle.Default.Size(6));
                    });

                    stack.Item().Row(row =>
                    {
                        row.RelativeColumn(1).ValueCell();
                        row.RelativeColumn(2).LabelCell("SUB TOTAL");
                        row.RelativeColumn(2).ValueCell().Text($"R{_subscriptions.Amount}", TextStyle.Default.Size(6));
                    });

                    stack.Item().Row(row =>
                    {
                        var vat = _subscriptions.Amount * 0.15;
                        row.RelativeColumn(1).ValueCell();
                        row.RelativeColumn(2).LabelCell("VAT");
                        row.RelativeColumn(2).ValueCell().Text($"R{vat}", TextStyle.Default.Size(6));
                    });

                    stack.Item().Row(row =>
                    {
                        var total = _subscriptions.Amount * 1.15;
                        row.RelativeColumn(1).ValueCell();
                        row.RelativeColumn(2).LabelCell("TOTAL");
                        row.RelativeColumn(2).ValueCell().Text($"R{total}", TextStyle.Default.Size(6));
                    });
                });
        }

        public void ConditionsOfContract(IContainer container)
        {
            container
               .Stack(stack =>
               {
                   stack.Item().Row(row =>
                   {
                       row.RelativeColumn().Stack(stack =>
                       {
                           stack.Item().Text("CONDITIONS OF CONTRACT", TextStyle.Default.SemiBold().Size(8));
                       });
                   });

                   stack.Item().Row(row =>
                   {
                       row.RelativeColumn().Stack(stack =>
                       {
                           stack.Item().Text(text =>
                           {
                               text.Line("1.) I acknowledge that all information and contents are left in ClinicManager’s custody and that ClinicManager shall not be liable or responsible in any way for any loss or damage of data and howsoever caused, including loss or damage caused by the negligence of its servants, employees or agents or any other persons, and all service or work done is subject to the terms and conditions contained on page 2 hereof.");
                               text.Line("2.) I authorise CARtime or its authorised agents to do the work listed above and to replace and supply such parts and materials including oil and petrols which may be necessary to complete the work set out above at my expense.");
                               text.Line("3.) Quotations valid for 14 days from date hereof.");
                           });
                       });
                   });

                   stack.Item().PageBreak();

                   stack.Item().Row(row =>
                   {
                       row.RelativeColumn().AlignCenter().Stack(stack =>
                       {
                           stack.Item().Text("STANDARD TERMS AND CONDITIONS FOR THE CARRYING OUT OF REPAIR / SERVICE /MAINTENANCE OR REPLACEMENT WORK", TextStyle.Default.SemiBold().Size(8));
                       });
                   });

                   stack.Item().Row(row =>
                   {
                       row.RelativeColumn().Stack(stack =>
                       {
                           stack.Item().Text(text =>
                           {
                               text.Line("These terms and conditions will only apply to the servicing, repairs, replacement, refurbishment or any related activities(the “Work”) that will be carried out on any vehicle(s) or parts, accessories or other items(collectively referred to as the 'Goods').");
                               text.Line("1. General").Underline(true);
                               text.Line("1.1.I have been advised to remove all items of value fromthe vehicle which are not required in order to carry out the Work when leaving the vehicle at a CARtime premises.CARtime does not accept liability for any loss or damage to any items left in the vehicle");
                               text.Line("1.2. CARtime will take all reasonable steps to take care of my vehicle or goods whilst in its possession, however I will have to pay for any loss or damage due to circumstances outside of CARtime’s control.The risk of damage or loss of the goods will remain my risk at all times and CARtime will only be held responsible for any loss, directly or indirectly attributable to its gross negligence ");
                               text.Line("1.3. I acknowledge that you have no obligation to provide me with a courtesy vehicle. However, if you agree do so as a gesture of goodwill, the provision and use of the courtesy vehicle will be subject to the availability of vehicles and on the terms and conditions as you determine.");
                           });

                           stack.Item().Stack(stack =>
                           {
                               stack.Item().Text(text =>
                               {
                                   text.Line("2. Authorisation of Repair Costs").Underline(true);
                                   text.Line("2.1. I warrant that the person affixing his/her signature to this document is duly authorised to approve any Work and I shall be bound thereto.");
                                   text.Line("2.2. I understand and agree that I am liable for any and all costs not paid by a warranty, motor / maintenance or service plan");
                                   text.Line("2.3. If the Work to be carried out is covered by a warranty, maintenance or service plan of the manufacturer of the vehicle, or any third party, CARtime will obtain the approval of the manufacturer or relevant party if necessary, before it starts any Work.If either the manufacturer or the relevant party refuses to pay for the required Work or parts, or if I am responsible to pay a portion of the costs, then CARtime will only proceed with the Work once I have agreed to pay for it and have specifically authorised CARtime to proceed with the Work.");
                                   text.Line("2.4. CARtime will provide me with an estimate (including stripping, diagnosing, quoting and reassembling) pertaining to any Work which I will personally be liable to pay for, and will obtain my prior approval before carrying out such Work.My_ approval of work to be carried out which I will be liable for may be qiven telephonically and / or electronically and / or digitally and may be carried out by CARtime or any agent or sub - contractor appointed by CARtime");
                                   text.Line("2.5. In the event that I have authorised Work to be carried out as is contemplated in clause 2.3 above, such additional Work will be subject to all these terms and conditions and will not be deemed to constitute a new or separate contact.");
                                   text.Line("2.6. If I cancel or fail to authorise the Work, then I will be liable to pay for the labour hours that CARtime spent working on the vehicle up to the date on which I gave CARtime notice of such cancellation");
                                   text.Line("2.7. I have been informed that CARtime does not collect, or arrange for vehicles to be collected.");
                                   text.Line("2.8. CARtime, or any of its designated employees, is entitled and authorised to drive the vehicle on public roads or elsewhere, if required to do so in connection with any inspection, or Work, or other purposes for which the vehicle is accepted by CARtime, including, but not limited to, the testing of the vehicle, determining the nature of the Work to be carried out, taking the vehicle for body repairs or taking be vehicle to any other third party service provider as referred to under paragraph 2.6 above.");
                                   text.Line("2.9. CARtime will carry out the Work as soon as is reasonably possible (bearing in mind that CARtime relies on the availability of parts and accessories).Any dates given for delivery and completion of the Work are estimates only and no exact delivery date or time has been agreed");
                                   text.Line("2.10. I acknowledge that the costs of the Work done by CARtime or its agent or sub-contractors or parts supplied by such entities may increase and I agree to pay the costs of such Work or parts, subject to my receiving notice and approving such increases before work commences.");
                               });
                           });

                           stack.Item().Stack(stack =>
                           {
                               stack.Item().Text(text =>
                               {
                                   text.Line("3. Payment Terms").Underline(true);
                                   text.Line("3.1 I understand that my Vehicle will only be released to me or my authorised representative once I have paid my account in full.");
                                   text.Line("3.2 The Work is completed for the purposes of these terms and conditions when I have received notice from CARtime that my vehicle is ready for collection.");
                                   text.Line("3.3 I understand that CARtime may require a deposit before commencing the Work.");
                                   text.Line("3.4 If CARtime informs me that the vehicle is ready for collection and I don't collect the vehicle within 5(five) business days of being notified, CARtime may charge me storage fees calculated from the notification date until the date of collection at a rate of R175 - 00(one hundred and seventy five Rand) per day.");
                               });
                           });
                       });

                       row.RelativeColumn().Stack(stack =>
                       {
                           stack.Item().Text(text =>
                           {
                               text.Line("3.5 I confirm and acknowledge that CARtime is entitled to dispose of my vehicle in any manner that CARtime deems fit(with or without a Court Order) for the purposes of recovering any amount due should I not collect my vehicle within 60 days of being notified that the vehicle is ready for collection and accordingly indemnify CARtime against any claims of whatsoever nature that maybe brought against CARtime now or in the future by myself or my successors in title, or beneficiaries or any other third party.");
                               text.Line("3.6 In addition to the storage costs, I confirm and acknowledge that CARtime is entitled to dispose of my vehicle in any manner that CARtime deems fit(with or without a Court Order) for the purposes of recovering any amount due to CARtime for which I am liable and accordingly indemnify CARtime against any claims of whatsoever nature that maybe brought against CARtime now or in the future by myself or my successors in title, or beneficiaries or any other third party");
                           });

                           stack.Item().Text(text =>
                           {
                               text.Line("4. Warranties").Underline(true);
                               text.Line("4.1 I have been informed that CARtime only uses new parts in carrying out the Work and warrants any new part installed during the Work and the labour required for the installation thereof, for a period of 6(six) months or 10 000km whichever comes first after the date ofsuch installation.");
                               text.Line("4.2 I have been informed that should I request CARtime to recondition parts in order to carry out the Work, CARtime only warrants such Work and the labour required for the installation thereof, for a period of 6(six) months after the date ofsuch installation.");
                               text.Line("4.3 Any applicable warranty will:");
                               text.Line("4.3.1 be void if I do not strictly comply with the terms and conditions of such warranty; ");
                               text.Line("4.3.2 not apply to ordinary wear and tear and normal usage of the vehicle;");
                           });

                           stack.Item().Text(text =>
                           {
                               text.Line("5. General Terms and Conditions").Underline(true);
                               text.Line("5.1 Any change to the terms and conditions of this agreement will only be valid if it is made in writing and signed by both of us.");
                               text.Line("5.2 No granting of any leeway or the granting of any extension of time will be a waiver of any rights under this agreement or a change in the terms of this agreement.");
                               text.Line("5.3 If any clause in this agreement is found to be unenforceable, such clause will be separated from this agreement, and this will not affect the enforceability of the remainder of the agreement(i.e. this Agreement will be read as if theunenforceable clause never formed part of this Agreement).");
                               text.Line("5.4 For the purpose of service of any legal documents or notices in terms of this Offer the parties choose the addresses on the face of this Job Card as their domicilium citandi et executandi for delivery or service of any legal documents or notice.Any notice can be delivered by hand at such address or by courier to such address or email to my nominated email address, and will be regarded as having been received by the party to whom it was so addressed.");
                               text.Line("5.5 If a party is in breach of this Agreement, the innocent party will have the right to recover all legal costs and disbursements on an attorney - and - clientscale.");
                               text.Line("5.6 CARtime will have a general right to retain the Goods and all its contents (a general right to keep the vehicle as security) for all monies owing to CARtime by me on any account whatsoever.");
                               text.Line("5.7 Any amount indicated or any invoice issued to me by CARtime will be regarded as a liquidated amount(a fixed amount or an amount that is easily determinable) and any such amount will be regarded as correct and due, owing and payable, by me to CARtime.");
                           });

                           stack.Item().Text("I hereby confirm that I have read and understood the terms and conditions of service.");

                           stack.Spacing(5);

                           stack.Item().Row(row =>
                           {
                               row.RelativeColumn(1).Text("CUSTOMER SIGNATURE", TextStyle.Default.Size(6));

                               row.RelativeColumn(1).Text("Date:", TextStyle.Default.Size(6));
                               row.RelativeColumn(1).Text(DateTime.Now.ToString("dd MMMM yyyy"), TextStyle.Default.Size(6));
                           });
                       });
                   });
               });
        }

    }

}
