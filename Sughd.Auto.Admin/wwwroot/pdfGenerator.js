window.generatePDF = (data) => {
    try {
        const cars = JSON.parse(data);
        console.log('Cars data:', cars); // Debug statement to check the data

        const { jsPDF } = window.jspdf;
        const doc = new jsPDF();

        const headers = [["№", "Id", "Marka", "Model", "DateOfPublisher", "UserPhoneNumber"]];
        const rows = cars.map(car => [car.Number, car.Id, car.MarkaName, car.ModelName, car.DateOfPublisher, car.UserPhoneNumber]);

        doc.autoTable({
            head: headers,
            body: rows,
        });

        doc.save("cars.pdf");
    } catch (error) {
        console.error('Error generating PDF:', error);
    }
};