<?php
	define('WP_USE_THEMES', false);
	require('wp-load.php');
	$questions = new WP_Query(array('posts_per_page' => 10,'post_type' => 'post'));
	if ( $questions->have_posts() ) {
        while ( $questions->have_posts() ) { 
            $questions->the_post();
            echo get_the_ID()."|";
            echo get_the_title()."|";
            echo get_the_content()."|";
            echo "/n";
        }
	}
	wp_reset_postdata();
?>
