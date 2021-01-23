<?php
    class First
    {
       
        public $item;
        function display()
        {
            $this->item1="First Class";
            echo $this->item1;
        }

       
    }
    

    class Second extends First 
    {
        public $item2;
        function display($a)
        {

            parent::$item1="jbjnn";
            $this->item2=$a;
            echo parent::$item1." ".$this->item2;
        }
    }
    class Third extends Second 
    {
        public $item2;
        function display($a,$b)
        {
            
            $this->item2=$a;                                                                                                                                                                                                                                                                                                                                                                            
            echo $this.item1." ".$this->item2;
        }
    }

    $FirstO=new First();
    $SecondO=new Second;
    $ThirdO=new Third;

    $FirstO->display();
    $SecondO->display("Second");
?>



