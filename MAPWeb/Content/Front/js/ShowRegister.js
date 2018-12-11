function Afficher() {
    
         if (document.getElementById('Client').checked) {
            document.getElementById('rs2').style.display = 'none';
           // document.getElementById('cd').style.display = 'none';
            document.getElementById('rs').style.display = 'none';
             //document.getElementById('rs3').style.display = 'none';
            document.getElementById('rs5').style.display = 'none';
            document.getElementById('rs6').style.display = 'none';
            document.getElementById('rs7').style.display = 'none';
        }
    }
    
  
    
    
function Afficher2() {

    if (document.getElementById('Resource').checked) {
        document.getElementById('rs').style.display = 'block';
        document.getElementById('rs2').style.display = 'block';
        document.getElementById('rs3').style.display = 'none';
        document.getElementById('rs4').style.display = 'none';
        document.getElementById('rs5').style.display = 'none';
        document.getElementById('rs6').style.display = 'none';
        document.getElementById('rs7').style.display = 'none';
        // document.getElementById('cl').style.display = 'none';
        // document.getElementById('cd').style.display = 'none';

    }
}
function Afficher3() {
    
    if (document.getElementById('Demandeur').checked) {
         document.getElementById('rs3').style.display = 'block';
         document.getElementById('rs4').style.display = 'block';
         document.getElementById('rs').style.display = 'none';
         document.getElementById('rs2').style.display = 'none';
         document.getElementById('rs5').style.display = 'block';
         document.getElementById('rs6').style.display = 'block';
         document.getElementById('rs7').style.display = 'block';
         
                // document.getElementById('cl').style.display = 'none';
                // document.getElementById('cd').style.display = 'none';
    
            }
    }